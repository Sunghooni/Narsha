using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselector : MonoBehaviour
{
    public void tutorial()
    {
        SceneManager.LoadScene("tutorial");
    }
    public void stage1click()
    {
        SceneManager.LoadScene("Stage1");
    }
}
