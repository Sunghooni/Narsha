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
        for (int i = 0; i < checkBocks.Length; i++)
        {
            Ray ray = new Ray(checkBocks[i].transform.position, Vector3.up);

            if (Physics.Raycast(ray, out RaycastHit hit, 2) && !hit.transform.CompareTag("Player"))
            {
                CodeBlock codeBlock = hit.transform.gameObject.GetComponent<CodeBlock>();
                input += codeBlock.code;

                if (i == 3)
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
        if (arrayCheck)
        {
            Ray ray = new Ray(enterBlock.transform.position, Vector3.up);

            if (Physics.Raycast(ray, out RaycastHit hit, 2f) && hit.transform.CompareTag("Player"))
            {
                enterCheck = true;
                player.GetComponent<BlockMove>().canInput = false;
            }
        }
    }
}
