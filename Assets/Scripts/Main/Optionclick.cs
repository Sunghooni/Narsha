using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Optionclick : MonoBehaviour
{
    public static bool isclicked;

    public void Start()
    {
       isclicked = false;
    }
    public void OnclickOption()
    {
        if (isclicked == false)
        {
            SceneManager.LoadScene("Option", LoadSceneMode.Additive);
            isclicked = true;
        }
    }
}
