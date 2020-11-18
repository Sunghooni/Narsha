using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClear : MonoBehaviour
{
    public Camera MainCamera, ClearCamera;
    public GameObject[] StageOneObject;
    public GameObject ClearCollider;
    public Vector3 InstantiatePosition;
    [SerializeField]
    int StageNumber;
    int StageOneShowWoodIdx = 0;
    private Coroutine ClearEventHandle; 
    public bool isClear;
    bool SetBlock = false;

    private void Awake()
    {
        ClearCamera.enabled = false;
    }

    void Update()
    {
        if (FindObjectOfType<ClearCheck>().winCheck)
        {
            if (!SetBlock)
            {
                ClearEventHandle = StartCoroutine(BlockInput());
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

    IEnumerator BlockInput()
    {
        while(true)
        {
            FindObjectOfType<BlockMove>().canInput = false;
            yield return new WaitForEndOfFrame();
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
        ClearCollider.SetActive(true);
        float timer = 0;
        SetBlock = true;
        for (double i = 0; i < StageOneObject.Length; i += 1)
        {
            Invoke("StageOneClear",  timer);
            timer += 0.2f;
        }
        Invoke("StageClearEnd", 2.2f);
    }

    void StageClearEnd()
    {
        ClearCollider.SetActive(false);
        FindObjectOfType<BlockMove>().canInput = true;
        ClearCamera.enabled = false;
        MainCamera.enabled = true;
        StopCoroutine(ClearEventHandle);
    }
}
