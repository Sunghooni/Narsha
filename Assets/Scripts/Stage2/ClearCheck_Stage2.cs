using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCheck_Stage2 : MonoBehaviour
{
    public GameObject[] checkBocks;
    public bool arrayCheck = false;

    private string lengthTemp = null;
    public int lengthNum = 0;

    private string[] answers = new string[3]{ "intLength=1;", "intLength=3;", "intLength=5;" };
    private string input;

    private void Update()
    {
        ArrayCheck();
        Debug.Log(lengthNum);
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

                if(i == checkBocks.Length - 2)
                {
                    lengthTemp = codeBlock.code;
                }
            }
        }
        if (input != null)
        {
            for(int i = 0; i < answers.Length; i++)
            {
                if (input.Equals(answers[i]))
                {
                    lengthNum = int.Parse(lengthTemp);
                    arrayCheck = true;
                    break;
                }
                else if(i == answers.Length - 1)
                {
                    lengthNum = 0;
                }
            }
            if(lengthNum == 0)
            {
                arrayCheck = false;
            }
        }
        lengthTemp = null;
        input = null;
    }
}
