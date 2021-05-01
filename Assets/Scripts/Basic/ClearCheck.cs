using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearCheck : MonoBehaviour
{
    public AudioManager audioManager;
    public GameObject[] checkBocks;
    public CodeBlock[] answerBocks;
    public InGameUIManager IGUI;
    public GameObject MissionText;
    public GameObject MissionPanel;

    public bool winCheck = false;
    public string answerCode = "START";

    private string input;

    void Update()
    {
        ArrayCheck();
    }

    void ArrayCheck()
    {
        for (int i = 0; i < checkBocks.Length; i++)
        {
            Ray ray = new Ray(checkBocks[i].transform.position, Vector3.up);
            int rayLength = 2;

            if (Physics.Raycast(ray, out RaycastHit hit, rayLength) && !hit.transform.CompareTag("Player"))
            {
                CodeBlock codeBlock = hit.transform.gameObject.GetComponent<CodeBlock>();
                input += codeBlock.code;
            }
        }
        if (input != null && input.Equals(answerCode))
        {
            if(input == "START")
            {
                if (!winCheck)
                {
                    audioManager.PlaySounds("CodeComplete");
                }
                 
                winCheck = true;
                MissionText.GetComponent<Text>().color = Color.green;
                IGUI.Clear();
            }
            else
            {
                 if (!winCheck)
                 {
                    audioManager.PlaySounds("CodeComplete");
                    MissionText.GetComponent<Text>().color = Color.green;

                    Invoke(nameof(StageOneChangeMission), 1.0f);
                    FixAnswerBlocks();
                 }
                winCheck = true;
            }
        }
        else
        {
            input = null;
        }
    }

    void StageOneChangeMission()
    {
        Vector2 missionTextSize = new Vector2(210, MissionText.GetComponent<RectTransform>().sizeDelta.y);
        Vector2 panelSize = new Vector2(220, 32);

        MissionText.GetComponent<Text>().text = "보물상자를 열어보세요";
        MissionText.GetComponent<Text>().color = Color.black;
        MissionText.GetComponent<RectTransform>().sizeDelta = missionTextSize;
        MissionPanel.GetComponent<RectTransform>().sizeDelta = panelSize;
    }

    void FixAnswerBlocks()
    {
        for(int i = 0; i < answerBocks.Length; i++)
        {
            answerBocks[i].tag = "Unmovable";
        }
    }
}
