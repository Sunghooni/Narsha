using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselector : MonoBehaviour
{
    GameObject audio;
    AudioSource audiosource;
    private LoadJsonData _LoadJsonData;

    private void Start()
    {
        audio = GameObject.FindWithTag("BGM");
        audiosource = audio.GetComponent<AudioSource>();
        _LoadJsonData = FindObjectOfType<LoadJsonData>();
    }
    public void TutorialClick()
    {
        LoadingScene.LoadScene("tutorial");
        audiosource.Stop();
    }
    public void Stage1Click()
    {
        if (_LoadJsonData.StageButton[1].colors.normalColor == _LoadJsonData.OffNormalColor)
        {
            return;
        }
        LoadingScene.LoadScene("Stage1");
        audiosource.Stop();
    }

    public void Stage2Click()
    {
        if (_LoadJsonData.StageButton[2].colors.normalColor == _LoadJsonData.OffNormalColor)
        {
            return;
        }
        LoadingScene.LoadScene("Stage2");
        audiosource.Stop();
    }

    public void Stage3Click()
    {
        if (_LoadJsonData.StageButton[3].colors.normalColor == _LoadJsonData.OffNormalColor)
        {
            return;
        }
        LoadingScene.LoadScene("Stage3");
        audiosource.Stop();
    }

    public void Stage4Click()
    {
        if (_LoadJsonData.StageButton[4].colors.normalColor == _LoadJsonData.OffNormalColor)
        {
            return;
        }
        LoadingScene.LoadScene("Stage4");
        audiosource.Stop();
    }

    public void Stage5Click()
    {
        if (_LoadJsonData.StageButton[5].colors.normalColor == _LoadJsonData.OffNormalColor)
        {
            return;
        }
        LoadingScene.LoadScene("Stage5");
        audiosource.Stop();
    }
    public void BeforeClick()
    {
        SceneManager.LoadScene("Main");
    }
}
