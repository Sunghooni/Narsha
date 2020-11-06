using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainbtnclick : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void onclickstart()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
