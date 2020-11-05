using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    public GameObject PausePanel, ClearPanel, firstBlock, player;
    bool isClear;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !ClearPanel.activeInHierarchy)
        {
            if (!PausePanel.activeInHierarchy)
            {
                PausePanel.SetActive(true);
                player.GetComponent<BlockMove>().canInput = false;
            }
            else
            {
                PausePanel.SetActive(false);
                if (FindObjectOfType<Tutorial>().idx > 4)
                    player.GetComponent<BlockMove>().canInput = true;
            }
        }
    }

    public void BackToStage()
    {
        SceneManager.LoadScene("Stage");
    }
    public void Clear()
    {
        ClearPanel.SetActive(true);
        player.GetComponent<BlockMove>().canInput = false;
    }

    public void ScaleAnimation() //도움말 창을 띄울때 필요한 함수입니다.
    {

    }

}
