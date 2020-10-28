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
    //private const float tolerance = 0.3f; // 허용 오차범위 (공차)
    private bool canMove = true;
    private bool isPressed = false;
    private Coroutine MoveCoroutine;
    Vector2 InputAxis;
    private Vector3 initialRotator;

    private void Awake()
    {
        initialRotator = transform.rotation.eulerAngles;
    }

    void Update()
    {
        GetInput();
        ResetBlock();
    }

    void GetInput()
    {
        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        InputAxis = new Vector2(horz, vert);

        if(InputAxis.sqrMagnitude > 0 && canInput)
        {
            if(!isPressed)
            {
                isPressed = true;
                MoveCoroutine = StartCoroutine(KeepMoving(InputAxis, 0.3f));
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

    IEnumerator KeepMoving(Vector2 input, float WaitBetweenMove)
    {
        while(isPressed)
        {
            float rot = VectorToDegree(new Vector2(input.x, input.y));
            player.transform.eulerAngles = new Vector3(initialRotator.x, -1 * DegreeLimit(rot, 90));
            /*
            if (InputAxis.x > 0)
                player.transform.eulerAngles = new Vector3(-90, 0, 0);
            else if (InputAxis.x < 0)
                player.transform.eulerAngles = new Vector3(-90, -180, 0);
            else if (InputAxis.y > 0)
                player.transform.eulerAngles = new Vector3(-90, -90, 0);
            else if (InputAxis.y < 0)
                player.transform.eulerAngles = new Vector3(-90, 90, 0);
            */
            Move(player);
            yield return new WaitForSeconds(WaitBetweenMove);
        }
    }

    float VectorToDegree(Vector2 vec)
    {
        Vector2 normalized = vec.normalized;
        float Acos = Mathf.Acos(normalized.x) * Mathf.Rad2Deg;
        float Asin = Mathf.Asin(normalized.y) * Mathf.Rad2Deg;
        float AcosSign = Mathf.Sign(Acos);
        float AsinSign = Mathf.Sign(Asin);


        float rot = Mathf.Max(Acos, Asin) * AcosSign * AsinSign;
        return rot;
    }

    float DegreeLimit(float rot, float unit)
    {
        return Mathf.Round(rot / unit) * unit;
    }

    void Move(GameObject me)
    {
        RaycastHit moveHit;
        Vector3 movePos = me.transform.position;

        if (me == player)
            canMove = true;

        if (Physics.Raycast(movePos, transform.right, out moveHit, 1f))
        {
            if (moveHit.transform.tag.Equals("Unmovable"))
            {
                canMove = false;
                return;
            }
            else
                Move(moveHit.transform.gameObject);
        }
        if(canMove)
        {
            movePos += transform.right * 1f;
            me.transform.position = movePos;
            AudioManager.GetInstance().PlaySounds("BasicMove");
        }
        return;
    }

    void ResetBlock()
    {
        if(Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}