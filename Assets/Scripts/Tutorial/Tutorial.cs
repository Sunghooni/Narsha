using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    string[] TutorialText;
    public int idx = 0;
    public Text content;
    public GameObject TutorialPanel, BlockArrow, AnswerBlockArrow, ClearPanel, PausePanel, Help;
    private void Awake()
    {
        TutorialText = new string[] { "WASD를 눌러 움직일 수 있어요" ,
                                                              "블럭을 밀어 옮겨보세요" ,
                                                              "R키를 눌러 다시 시작 할 수 있어요",
                                                              "느낌표 버튼을 눌러 힌트를 받으세요",
                                                              "왼쪽 위 미션을 수행하세요",
                                                              "ESC키를 눌러 일시정지 할 수 있어요",
                                                              "정답블럭칸에 START를 맞춰보세요!"};
        content.text = TutorialText[idx];
        BlockArrow.SetActive(false);
        AnswerBlockArrow.SetActive(false);
        FindObjectOfType<BlockMove>().canInput = false;
    }

    private void Start()
    {
        ShowObject();
    }

    void Update()
    {
        ControlText();
        //ShowObject();
    }

    private void ControlText()
     {
        if(Input.GetKeyDown(KeyCode.Space) && !PausePanel.activeInHierarchy)
          {
            idx++;
            if (idx > 6 && !ClearPanel.activeInHierarchy)
               {
                AnswerBlockArrow.SetActive(false);
                TutorialPanel.SetActive(false);
                FindObjectOfType<BlockMove>().canInput = true;
                Debug.Log(FindObjectOfType<BlockMove>().gameObject.name);
                return;
              }
            content.text = TutorialText[idx];
            ShowObject();
           
           }

      }

    private void ShowObject()
    {
        switch(idx)
        {
            case 1:
                BlockArrow.SetActive(true);
                break;
            case 2:
                BlockArrow.SetActive(false);
                break;
            case 6:
                AnswerBlockArrow.SetActive(true);
                break;
        }
    }

}