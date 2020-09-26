using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    public GameObject player;
    public GameObject firstBlock;
    public bool canInput = true;
    public bool canMove = true;
    public bool winCheck = false;

    private RaycastHit moveHit;
    private RaycastHit checkHit;

    public int nameCnt = 1;
    private int maxCnt = 3;

    void Update()
    {
        GetInput();
        ArrayCheck(firstBlock);
    }

    void GetInput()
    {
        if(canInput)
        {
            if (Input.GetKey(KeyCode.W))
            {
                StartCoroutine(InputCheck());
                player.transform.eulerAngles = new Vector3(0, 0, 0);
                Move(player);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                StartCoroutine(InputCheck());
                player.transform.eulerAngles = new Vector3(0, -90, 0);
                Move(player);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                StartCoroutine(InputCheck());
                player.transform.eulerAngles = new Vector3(0, -180, 0);
                Move(player);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                StartCoroutine(InputCheck());
                player.transform.eulerAngles = new Vector3(0, 90, 0);
                Move(player);
            }
        }
    }

    void Move(GameObject me)
    {
        if (me == player)
            canMove = true;

        Vector3 movePos = me.transform.position;
        movePos += transform.right * 5;
        movePos += transform.up * 5;

        if (Physics.Raycast(movePos, Vector3.down, out moveHit, 4.7f))
        {
            if(moveHit.transform.name == "block1")
            {
                canMove = false;
                return;
            }
            else
                Move(moveHit.transform.gameObject);
        }
        if(canMove)
        {
            movePos -= transform.up * 5;
            me.transform.position = movePos;
        }
        return;
    }

    IEnumerator InputCheck()
    {
        canInput = false;
        float timer = 0;

        while(true)
        {
            timer += Time.deltaTime;
            if(timer >= 0.2f)
            {
                canInput = true;
                break;
            }
            yield return null;
        }
    }

    void ArrayCheck(GameObject me)
    {
        if (nameCnt == maxCnt)
        {
            winCheck = true;
            return;
        }

        nameCnt += 1;

        Vector3 movePos = me.transform.position;
        movePos += -Vector3.forward * 5;
        movePos += Vector3.up * 5;

            if (Physics.Raycast(movePos, Vector3.down, out checkHit, 4.7f))
            {
                if (checkHit.transform.name == "block" + nameCnt.ToString())
                    ArrayCheck(checkHit.transform.gameObject);
            else
            {
                nameCnt = 1;
                return;
            }
        }
        else
        {
            nameCnt = 1;
            return;
        }
    }
}