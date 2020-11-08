using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClear : MonoBehaviour
{
    public Camera MainCamera, ClearCamera;
    public GameObject ClearObject;
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
        for (int i = 0; i < StageOneObject.Length; i++)
        {
            Invoke("StageOneClear",  i / 1.5f);
        }
        Invoke("StageClearEnd", 7.0f);
    }

    void StageClearEnd()
    {
        ClearCamera.enabled = false;
        MainCamera.enabled = true;
    }
}
