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
        isClear = firstBlock.GetComponent<ClearCheck>().winCheck;
        if(Input.GetKeyDown(KeyCode.Escape) && isClear == false)
        {
            if (!PausePanel.activeInHierarchy)
            {
                PausePanel.SetActive(true);
                player.GetComponent<BlockMove>().canInput = false;
            }
            else
            {
                PausePanel.SetActive(false);
                player.GetComponent<BlockMove>().canInput = true;
            }
        }

        if (isClear)
        {
            ClearPanel.SetActive(true);
            player.GetComponent<BlockMove>().canInput = false;
        }
        else
            ClearPanel.SetActive(false);

    }

    public void BackToStage()
    {
        SceneManager.LoadScene("Stage");
    }

}
