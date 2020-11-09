using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    public GameObject PausePanel, ClearPanel, DiePanel,  firstBlock, player, Help;
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
                if (FindObjectOfType<ClearCheck>().answerCode == "START")
                {
                    if (FindObjectOfType<Tutorial>().idx > 4)
                        player.GetComponent<BlockMove>().canInput = true;
                }
                else
                    player.GetComponent<BlockMove>().canInput = true;
            }
        }
    }

    public void Die()
    {
        DiePanel.SetActive(true);
        player.GetComponent<BlockMove>().canInput = false;
    }

    public void ReSpawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToStage()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void Clear()
    {
        ClearPanel.SetActive(true);
        player.GetComponent<BlockMove>().canInput = false;
    }

    public void ScaleAnimation() //도움말 창을 띄울때 필요한 함수입니다.
    {
        float Timer = 0;
        Help.transform.localScale = Vector3.one;

        Help.transform.localScale = Vector3.one * (1 + Timer);
    }

}
