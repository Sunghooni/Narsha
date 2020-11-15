using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselector : MonoBehaviour
{
    public void tutorial()
    {
        LoadingScene.LoadScene("tutorial");
    }
    public void stage1click()
    {
        LoadingScene.LoadScene("Stage1");
    }
    public void beforeClick()
    {
        SceneManager.LoadScene("Main");
    }
}
