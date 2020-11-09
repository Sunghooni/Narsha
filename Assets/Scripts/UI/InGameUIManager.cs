using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    public GameObject PausePanel, ClearPanel, DiePanel,  firstBlock, player, Help, ShowHelpImage;
    public string HelpMessage;
    bool HelpSelect = false;

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
                    if (FindObjectOfType<Tutorial>().idx > 5)
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
        player.GetComponent<BlockMove>().canInput = false;
        ClearPanel.SetActive(true);
    }

    public void OnClickHelp()
    {
        if (FindObjectOfType<Tutorial>().idx > 5)
            player.GetComponent<BlockMove>().canInput = true;
        if (!HelpSelect)
        {
            this.gameObject.SetActive(false);
            ShowHelpImage.SetActive(true);
            HelpSelect = true;
        }
        else
        {
            this.gameObject.SetActive(true);
            ShowHelpImage.SetActive(false);
            HelpSelect = false;
        }
        ShowHelpImage.GetComponentInChildren<Text>().text = HelpMessage;
    }
}
