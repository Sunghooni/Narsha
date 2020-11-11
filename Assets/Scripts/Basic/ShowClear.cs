using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClear : MonoBehaviour
{
    public Camera MainCamera, ClearCamera;
    public GameObject[] StageOneObject;
    public Vector3 InstantiatePosition;
    [SerializeField]
    int StageNumber;
    int StageOneShowWoodIdx = 0;
    public bool isClear;

    private void Awake()
    {
        ClearCamera.enabled = false;
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
        ++StageOneShowWoodIdx;
        Debug.Log(StageOneShowWoodIdx); 
    }

    void StageOne()
    {
        isClear = true;
        float timer = 0;
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
