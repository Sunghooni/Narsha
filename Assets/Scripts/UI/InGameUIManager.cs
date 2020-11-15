using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    public GameObject PausePanel, ClearPanel, DiePanel, player, Help, ShowHelpImage, MissionText, TutorialPanel;
    public string HelpMessage;
    public string[] MissionMessage;
    bool HelpSelect = false;

    private void Update()
    {
        GamePause();
    }

    void GamePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !ClearPanel.activeInHierarchy && !DiePanel.activeInHierarchy)
        {
            if (!PausePanel.activeInHierarchy)
            {
                PausePanel.SetActive(true);
                player.GetComponent<BlockMove>().canInput = false;
                Time.timeScale = 0f;
            }
            else
            {
                PausePanel.SetActive(false);
                if (FindObjectOfType<ClearCheck>().answerCode == "START")
                    FindObjectOfType<BlockMove>().canInput = true;
                else
                    player.GetComponent<BlockMove>().canInput = true;
                Time.timeScale = 1f;
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

    public void BackToStageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void GoNextStage()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void ContinueGame()
    {
        PausePanel.SetActive(false);
        player.GetComponent<BlockMove>().canInput = true;
        Time.timeScale = 1f;
    }

    public void Clear()
    {
        player.GetComponent<BlockMove>().canInput = false;
        ClearPanel.SetActive(true);
    }

    public void OnClickHelp()
    {
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
