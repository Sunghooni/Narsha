using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClear : MonoBehaviour
{
    public Camera MainCamera, ClearCamera;
    public GameObject ClearObject;
    public Vector3 InstantiatePosition;
    [SerializeField]
    int StageNumber;
    public bool isClear;

    private void Awake()
    {
        ClearCamera.enabled = false;
    }

    void Update()
    {
        if (FindObjectOfType<ClearCheck>().winCheck)
        {
            switch (StageNumber)
            {
                case 1:
                    MainCamera.enabled = false;
                    ClearCamera.enabled = true;
                    Invoke("StageOneClear", 2.0f);
                    isClear = true;
                    return;
                case 2:
                    return;
            }
        }
    }

    void StageOneClear()
    {
        Instantiate(ClearObject, InstantiatePosition, Quaternion.identity);
        
    }
}
