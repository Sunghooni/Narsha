using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleVolume : MonoBehaviour
{
    AudioSource audio;

    private void Awake()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        audio.volume = OptionValues.GetVolume();
    }
}
