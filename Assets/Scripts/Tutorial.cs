using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    string[] TutorialText;
    bool oneClear = false, twoClear = false, threeClear = false;
    public Text content;
    public GameObject W, A, S, D, Arrow, Block;
    float CurTime = 0;
    private void Awake()
    {
        TutorialText = new string[] { "WASD를 눌러 움직여보세요" ,
                                                              "블럭을 밀어 옮겨보세요" ,
                                                              "정답블럭칸에 START를 맞춰보세요!"};
    }

    private void Start()
    {
        content.text = TutorialText[0];
        Arrow.SetActive(false);
    }
    void Update()
    {
        ControlText();
        if (!oneClear)
        {
            ClearOne();
        }
        if (!twoClear)
        {
            ClearTwo();
        }
    }

    void ControlText()
    {
        if (oneClear)
        {
            if (twoClear)
            {
                content.text = TutorialText[2];
                return;
            }
            content.text = TutorialText[1];
        }


    }

    void ClearOne()
    {
        if (!W.activeInHierarchy && !A.activeInHierarchy && !S.activeInHierarchy && !D.activeInHierarchy)
        {
            oneClear = true;
            Arrow.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.W))
            W.SetActive(false);
        if (Input.GetKeyDown(KeyCode.A))
            A.SetActive(false);
        if (Input.GetKeyDown(KeyCode.S))
            S.SetActive(false);
        if (Input.GetKeyDown(KeyCode.D))
            D.SetActive(false);

    }

    void ClearTwo()
    {
        if (Block.transform.position.x != -1.1516)
        {
            Arrow.SetActive(false);
            twoClear = true;
        }
    }

    void ClearThree()
    {

    }

}
