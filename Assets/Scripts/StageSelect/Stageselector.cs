using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselector : MonoBehaviour
{
    GameObject audio;
    AudioSource audiosource;

    private void Start()
    {
        audio = GameObject.FindWithTag("BGM");
        audiosource = audio.GetComponent<AudioSource>();
    }
    public void TutorialClick()
    {
        LoadingScene.LoadScene("tutorial");
        audiosource.Stop();
    }
    public void Stage1Click()
    {
        if (FindObjectOfType<LoadJsonData>().StageButton[1].colors.normalColor == FindObjectOfType<LoadJsonData>().OffNormalColor)
            return;
        LoadingScene.LoadScene("Stage1");
        audiosource.Stop();
    }

    public void Stage2Click()
    {
        if (FindObjectOfType<LoadJsonData>().StageButton[2].colors.normalColor == FindObjectOfType<LoadJsonData>().OffNormalColor)
            return;
        LoadingScene.LoadScene("Stage2");
        audiosource.Stop();
    }

    public void Stage3Click()
    {
        if (FindObjectOfType<LoadJsonData>().StageButton[3].colors.normalColor == FindObjectOfType<LoadJsonData>().OffNormalColor)
            return;
        LoadingScene.LoadScene("Stage3");
        audiosource.Stop();
    }

    public void Stage4Click()
    {
        if (FindObjectOfType<LoadJsonData>().StageButton[4].colors.normalColor == FindObjectOfType<LoadJsonData>().OffNormalColor)
            return;
        LoadingScene.LoadScene("Stage4");
        audiosource.Stop();
    }

    public void Stage5Click()
    {
        if (FindObjectOfType<LoadJsonData>().StageButton[5].colors.normalColor == FindObjectOfType<LoadJsonData>().OffNormalColor)
            return;
        LoadingScene.LoadScene("Stage5");
        audiosource.Stop();
    }
    public void beforeClick()
    {
        SceneManager.LoadScene("Main");
    }
}
