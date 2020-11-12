using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClear : MonoBehaviour
{
    public Camera MainCamera, ClearCamera;
    public GameObject[] StageOneObject;
    public Vector3 InstantiatePosition;
    public AudioClip WaterSound;
    AudioSource water;
    [SerializeField]
    int StageNumber;
    int StageOneShowWoodIdx = 0;
    public bool isClear;
    float timer = 0;

    private void Awake()
    {
        ClearCamera.enabled = false;
        water = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (FindObjectOfType<ClearCheck>().winCheck)
        {
            if (!isClear)
            {
                FindObjectOfType<BlockMove>().canInput = false;
                ClearCamera.enabled = true;
                MainCamera.enabled = false;

                switch (StageNumber)
                   {
                    case 1:
                        StageOne();
                        break;
                    }
            }
        }
    }

    void StageOneClear()
    {
        StageOneObject[StageOneShowWoodIdx].SetActive(true);
        if (timer == 0.2f)
            //WaterSound.
        ++StageOneShowWoodIdx;
        Debug.Log(StageOneShowWoodIdx); 
    }

    void StageOne()
    {
        isClear = true;
        for (double i = 0; i < StageOneObject.Length; i += 1)
        {
            Invoke("StageOneClear",  timer);
            timer += 0.2f;
        }
        Invoke("StageClearEnd", 2.2f);
    }

    void StageClearEnd()
    {
        FindObjectOfType<BlockMove>().canInput = true;
        ClearCamera.enabled = false;
        MainCamera.enabled = true;
    }
}
