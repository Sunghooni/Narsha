using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockMove : MonoBehaviour
{
    public GameObject player;
    public bool canInput = true;
    public bool groundCheck = true;
    public float inputCtrl = 1;

    private bool canMove = true;
    private bool isPressed = false;
    private Coroutine MoveCoroutine;
    private Vector2 InputAxis;
    private Vector3 initialRotator;
    private const float delay = 0.3f;

    private void Awake()
    {
        initialRotator = transform.rotation.eulerAngles;
    }

    void Update()
    {
        IsGround();
        GetInput();
        ResetBlock();
        AudioManager.VolumeSize(float.Parse(OptionValues.GetVolume().ToString()));
    }

    void GetInput()
    {
        float horz = Input.GetAxisRaw(OptionValues.GetHzKey()) * inputCtrl;
        float vert = Input.GetAxisRaw(OptionValues.GetVtKey()) * inputCtrl;
        InputAxis = new Vector2(horz, vert);

        if (InputAxis.sqrMagnitude > 0 && canInput)
        {
            if(!isPressed)
            {
                isPressed = true;
                MoveCoroutine = StartCoroutine(KeepMoving(delay));
            }
        }
        else
        {
            isPressed = false;
            if (MoveCoroutine != null)
            {
                StopCoroutine(MoveCoroutine);
            }
        }
    }

    IEnumerator KeepMoving(float WaitBetweenMove)
    {
        while (isPressed)
        {
            float degree = MathFunctionLibrary.VectorToDegree(new Vector2(InputAxis.x, InputAxis.y));
            player.transform.eulerAngles = new Vector3(initialRotator.x, -1 * MathFunctionLibrary.SnapByUnit(degree, 90));
            Move(player);
            yield return new WaitForSeconds(WaitBetweenMove);
        }
    }

    private void Move(GameObject me)
    {
        Vector3 movePos = me.transform.position;

        if (me == player)
        {
            canMove = true;
        }
        if (Physics.Raycast(movePos, transform.right, out RaycastHit moveHit, 1)) 
        {
            if (moveHit.transform.CompareTag("Unmovable"))
            {
                canMove = false;
                return;
            }
            else
            {
                Move(moveHit.transform.gameObject);
            }
        }
        if (canMove)
        {
            movePos += transform.right;
            me.transform.position = movePos;
            AudioManager.GetInstance().PlaySounds("BasicMove");
        }
        return;
    }

    void ResetBlock()
    {
        if (Input.GetKeyDown(KeyCode.R) && canInput)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void IsGround()
    {
        if (!Physics.Raycast(gameObject.transform.position, Vector3.down, 0.5f))
        {
            inputCtrl = 0;
        }
        else
        {
            inputCtrl = 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("WaterBlocks"))
        {
            canInput = false;
            FindObjectOfType<InGameUIManager>().Die();
        }
    }
}