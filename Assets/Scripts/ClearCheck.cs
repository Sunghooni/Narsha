using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCheck : MonoBehaviour
{
    private int nameCnt = 1;
    private int maxCnt = 3;
    public bool winCheck = false;

    void Update()
    {
        ArrayCheck(this.transform.position);
    }

    void ArrayCheck(Vector3 me)
    {
        
    }
}
