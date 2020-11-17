using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainbtnclick : MonoBehaviour
{
    GameObject BGM;
    // Start is called before the first frame update
    public void Start()
    {
        BGM = GameObject.Find("StartMusic");
    }
    public void onclickstart()
    {   
        BGM.gameObject.tag = "BGM";
        DontDestroyOnLoad(BGM);
        SceneManager.LoadScene("StageSelect");  
    }
}
