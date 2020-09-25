using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    public GameObject player;
    public bool canInput = true;
    public bool canMove = true;

    private RaycastHit hit;

    void Update()
    {
        GetInput();
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

        if (Physics.Raycast(movePos, Vector3.down, out hit, 4.7f))
        {
            if(hit.transform.name == "block1")
            {
                canMove = false;
                return;
            }
            else
                Move(hit.transform.gameObject);
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
}