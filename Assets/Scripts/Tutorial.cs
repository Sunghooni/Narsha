using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    string[] TutorialText;
    public int idx = 0;
    public Text content;
    public GameObject TutorialPanel, WASD, BlockArrow, AnswerBlockArrow, ClearPanel;
    private void Awake()
    {
        TutorialText = new string[] { "WASD를 눌러 움직여보세요" ,
                                                              "블럭을 밀어 옮겨보세요" ,
                                                              "R키를 눌러 다시 시작 할 수 있어요",
                                                              "ESC키를 눌러 일시정지 할 수 있어요",
                                                              "정답블럭칸에 START를 맞춰보세요!",};
        content.text = TutorialText[idx];
        WASD.SetActive(false);
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
        if(Input.GetKeyDown(KeyCode.Space))
          {
            idx++;
            if (idx > 4 && !ClearPanel.activeInHierarchy)
               {
                AnswerBlockArrow.SetActive(false);
                TutorialPanel.SetActive(false);
                FindObjectOfType<BlockMove>().canInput = true;
                return;
              }
            content.text = TutorialText[idx];
            ShowObject();
           
           }

      }

    private void ShowObject()
    {
        if(idx == 0)
        {
            WASD.SetActive(true);
        }
        if(idx == 1)
        {
            WASD.SetActive(false);
            BlockArrow.SetActive(true);
        }
        if(idx == 2 || idx == 3)
        {
            BlockArrow.SetActive(false);
        }
        if(idx == 4)
        {
            AnswerBlockArrow.SetActive(true);
        }
    }
}
