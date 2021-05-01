using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClear : MonoBehaviour
{
    public Camera MainCamera;
    public Camera ClearCamera;
    public GameObject[] StageOneObject;
    public GameObject ClearCollider;
    public Vector3 InstantiatePosition;
    public bool isClear;
    public int StageNumber;

    private int StageOneShowWoodIdx = 0;
    private Coroutine ClearEventHandle; 
    private bool SetBlock = false;

    private void Awake()
    {
        ClearCamera.enabled = false;
    }

    private void Update()
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

    private void StageOneClear()
    {
        StageOneObject[StageOneShowWoodIdx].SetActive(true);
        ++StageOneShowWoodIdx;
    }

    private void StageOne()
    {
        float timer = 0;

        ClearCollider.SetActive(true);
        SetBlock = true;

        for (double i = 0; i < StageOneObject.Length; i += 1)
        {
            Invoke(nameof(StageOneClear), timer);
            timer += 0.2f;
        }
        Invoke(nameof(StageClearEnd), 2.2f);
    }

    private void StageClearEnd()
    {
        ClearCollider.SetActive(false);
        FindObjectOfType<BlockMove>().canInput = true;
        ClearCamera.enabled = false;
        MainCamera.enabled = true;
        StopCoroutine(ClearEventHandle);
    }
}
