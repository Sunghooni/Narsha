using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCheck_Stage3 : MonoBehaviour
{
    public GameObject[] checkBocks;
    public CodeBlock[] answerBocks;
    public GameObject enterBlock;
    public bool arrayCheck = false;
    public bool enterCheck = false;
    public GameObject player;
    public string sign = null;

    private string[] answerCode = { "While(i<=5){}", "While(i<5){}", "While(i==5){}" };
    private string input;

    private void Update()
    {
        ArrayCheck();
        EnterCheck();
    }

    void ArrayCheck()
    {
        RaycastHit hit;
        for (int i = 0; i < checkBocks.Length; i++)
        {
            if (Physics.Raycast(checkBocks[i].transform.position, Vector3.up, out hit, 2) && hit.transform.tag != "Player")
            {
                CodeBlock codeBlock = hit.transform.gameObject.GetComponent<CodeBlock>();
                input += codeBlock.code;

                if(i == 3)
                {
                    sign = codeBlock.code;
                    Debug.Log(sign);
                }
            }
        }
        if (input != null)
        {
            for(int i = 0; i < answerCode.Length; i++)
            {
                if(input.Equals(answerCode[i]))
                {
                    Debug.Log("Right!");
                    arrayCheck = true;
                    break;
                }
                else
                {
                    arrayCheck = false;
                    sign = null;
                }
            }
        }
        input = null;
    }

    void EnterCheck()
    {
        RaycastHit hit;
        if(arrayCheck)
        {
            if (Physics.Raycast(enterBlock.transform.position, Vector3.up, out hit, 2f) && hit.transform.tag.Equals("Player"))
            {
                enterCheck = true;
                player.GetComponent<BlockMove>().canInput = false;
            }
        }
    }
}
