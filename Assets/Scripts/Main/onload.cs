using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onload : MonoBehaviour
{
    GameObject Audio;
    AudioSource audiosource;
    private void Start()
    {
        Audio = GameObject.FindWithTag("bgm1");
        audiosource = Audio.GetComponent<AudioSource>();

        if (GameObject.FindWithTag("BGM") != null)
        {
            Destroy(Audio);
        }
        audiosource.volume = OptionValues.GetVolume();
    }

    void Update()
    {
        audiosource.volume = OptionValues.GetVolume();
    }
}
