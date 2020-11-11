using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearCheck : MonoBehaviour
{
    public AudioManager audioManager;

    public GameObject[] checkBocks;
    public CodeBlock[] answerBocks;
    public bool winCheck = false;
    public InGameUIManager IGUI;

    public string answerCode = "START";
    private string input;
    public GameObject MissionText;

    void Update()
    {
        ArrayCheck();
    }

    void ArrayCheck()
    {
        RaycastHit hit;
        for(int i = 0; i < checkBocks.Length; i++)
        {
            if(Physics.Raycast(checkBocks[i].transform.position, Vector3.up, out hit, 2) && hit.transform.tag != "Player")
            {
                CodeBlock codeBlock = hit.transform.gameObject.GetComponent<CodeBlock>();
                input += codeBlock.code;
            }
        }
        if (input != null && input.Equals(answerCode))
        {
            if(input == "START")
              {
                Debug.Log("Clear");
                if (!winCheck)
                    audioManager.PlaySounds("CodeComplete");
                 
                winCheck = true;
                MissionText.GetComponent<Text>().color = Color.green;
                IGUI.Clear();
              }
           else
            {
                if (!winCheck)
                    audioManager.PlaySounds("CodeComplete");
                MissionText.GetComponent<Text>().color = Color.green;
                winCheck = true;
            }
        }
        else
            input = null;
    }
}
