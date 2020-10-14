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
    public AudioSource playerMoving;
    public bool canInput = true;
    private bool canMove = true;

    void Update()
    {
        GetInput();
        ResetBlock();
    }

    void GetInput()
    {
        if(canInput)
        {
            if (Input.GetKey(KeyCode.W))
            {
                StartCoroutine(InputCheck());
                player.transform.eulerAngles = new Vector3(0, -90, 0);
                Move(player);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                StartCoroutine(InputCheck());
                player.transform.eulerAngles = new Vector3(0, -180, 0);
                Move(player);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                StartCoroutine(InputCheck());
                player.transform.eulerAngles = new Vector3(0, 90, 0);
                Move(player);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                StartCoroutine(InputCheck());
                player.transform.eulerAngles = new Vector3(0, 0, 0);
                Move(player);
            }
        }
    }

    void Move(GameObject me)
    {
        RaycastHit moveHit;

        if (me == player)
            canMove = true;

        Vector3 movePos = me.transform.position;
        movePos += transform.right * 1;
        movePos += transform.up * 1;

        if (Physics.Raycast(movePos, Vector3.down, out moveHit, 0.7f))
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
            movePos -= transform.up * 1;
            me.transform.position = movePos;
            AudioManager.GetInstance().PlaySounds("BasicMove");
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
            if(timer >= 0.3f)
            {
                canInput = true;
                break;
            }
            yield return null;
        }
    }

    void ResetBlock()
    {
        if(Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}