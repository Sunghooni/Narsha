using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onload : MonoBehaviour
{
    GameObject audioSource;
    private void Start()
    {
        audioSource = GameObject.FindWithTag("bgm1");
        if (GameObject.FindWithTag("BGM") != null)
        {
            Destroy(audioSource);
        }
        else
        {

        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
