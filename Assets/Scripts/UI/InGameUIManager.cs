using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;

public class InGameUIManager : MonoBehaviour
{
    public GameObject PausePanel, ClearPanel, DiePanel, player, Help, ShowHelpImage, MissionText, TutorialPanel;
    public string HelpMessage, NextStage;
    public string[] MissionMessage;
    string JsonPath, JsonData;
    int StageNumber;
    bool HelpSelect = false;
    GameObject audio;
    AudioSource audioSource;

    private void Awake()
    {
        JsonPath = Application.dataPath + "/Resources/StageClear.json";
        JsonData = File.ReadAllText(JsonPath);

        JsonData = Regex.Replace(JsonData, @"\D", "");
        StageNumber = int.Parse(JsonData);

        audio = GameObject.FindWithTag("BGM");
        audioSource = audio.GetComponent<AudioSource>();
    }

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
        audioSource.Play();
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Main");
        audioSource.Play();
    }

    public void GoNextStage()
    {
        LoadingScene.LoadScene("Stage" + NextStage);
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
        if (StageNumber >= int.Parse(NextStage))
            return;
        File.WriteAllText(JsonPath, NextStage);
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
