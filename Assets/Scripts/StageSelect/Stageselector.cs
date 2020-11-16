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
    public void tutorial()
    {
        LoadingScene.LoadScene("tutorial");
        Destroy(audio);
    }
    public void stage1click()
    {
        LoadingScene.LoadScene("Stage1");
        Destroy(audio);
    }
    public void beforeClick()
    {
        SceneManager.LoadScene("Main");
    }
}
