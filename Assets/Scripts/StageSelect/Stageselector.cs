using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselector : MonoBehaviour
{
    GameObject audio;

    private void Start()
    {
        audio = GameObject.FindWithTag("BGM");
    }
    public void TutorialClick()
    {
        LoadingScene.LoadScene("tutorial");
        Destroy(audio);

    }
    public void Stage1Click()
    {
        if (FindObjectOfType<LoadJsonData>().StageButton[1].colors.normalColor == FindObjectOfType<LoadJsonData>().OffNormalColor)
            return;
        LoadingScene.LoadScene("Stage1");
        Destroy(audio);
    }

    public void Stage2Click()
    {
        if (FindObjectOfType<LoadJsonData>().StageButton[2].colors.normalColor == FindObjectOfType<LoadJsonData>().OffNormalColor)
            return;
        LoadingScene.LoadScene("Stage2");
        Destroy(audio);
    }

    public void Stage3Click()
    {
        if (FindObjectOfType<LoadJsonData>().StageButton[3].colors.normalColor == FindObjectOfType<LoadJsonData>().OffNormalColor)
            return;
        LoadingScene.LoadScene("Stage3");
        Destroy(audio);
    }

    public void Stage4Click()
    {
        if (FindObjectOfType<LoadJsonData>().StageButton[4].colors.normalColor == FindObjectOfType<LoadJsonData>().OffNormalColor)
            return;
        LoadingScene.LoadScene("Stage4");
        Destroy(audio);
    }

    public void Stage5Click()
    {
        if (FindObjectOfType<LoadJsonData>().StageButton[5].colors.normalColor == FindObjectOfType<LoadJsonData>().OffNormalColor)
            return;
        LoadingScene.LoadScene("Stage5");
        Destroy(audio);
    }
    public void beforeClick()
    {
        SceneManager.LoadScene("Main");
    }
}
