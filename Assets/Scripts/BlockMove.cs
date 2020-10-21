using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockMove : MonoBehaviour
{
    public GameObject player;
    public bool canInput = true;
    //private const float tolerance = 0.3f; // 허용 오차범위 (공차)
    private bool canMove = true;
    private bool isReleased = false;
    private Coroutine MoveCoroutine;

    void FixedUpdate()
    {
        GetInput();
        ResetBlock();
    }

    void GetInput()
    {
        if(canInput)
        {
            float horz = Input.GetAxisRaw("Horizontal");
            float vert = Input.GetAxisRaw("Vertical");
            Vector2 InputAxis = new Vector2(horz, vert);
            if(InputAxis.sqrMagnitude > 0)
            {
                
                if(!isReleased)
                {
                    isReleased = true;
                    MoveCoroutine = StartCoroutine(KeepMoving(InputAxis, 0.3f));
                }
            }
            else
            {
                isReleased = false;
                if (MoveCoroutine != null)
                {
                    StopCoroutine(MoveCoroutine);
                }
            }
        }
    }

    IEnumerator KeepMoving(Vector2 Input, float WaitBetweenMove)
    {
        while(isReleased)
        {
            if (Input.x > 0)
                player.transform.eulerAngles = new Vector3(-90, 0, 0);
            else if (Input.x < 0)
                player.transform.eulerAngles = new Vector3(-90, -180, 0);
            else if (Input.y > 0)
                player.transform.eulerAngles = new Vector3(-90, -90, 0);
            else if (Input.y < 0)
                player.transform.eulerAngles = new Vector3(-90, 0, 90);
            Move(player);
            yield return new WaitForSeconds(WaitBetweenMove);
        }
    }

    void Move(GameObject me)
    {
        RaycastHit moveHit;

        if (me == player)
            canMove = true;

        Vector3 movePos = me.transform.position;
        movePos += transform.right * 1;
        movePos += transform.forward * 1f;

        if (Physics.Raycast(movePos, Vector3.down, out moveHit, 1f))
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
            movePos -= transform.forward * 1f;
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