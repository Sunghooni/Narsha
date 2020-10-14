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
        RaycastHit checkHit;
        Vector3 newPos = me;
        if (nameCnt == maxCnt)
        {
            winCheck = true;
            return;
        }

        nameCnt += 1;

        Vector3 movePos = me;
        movePos += -Vector3.forward * 1;
        movePos += Vector3.up * 1;

        if (Physics.Raycast(movePos, Vector3.down, out checkHit, 0.7f))
        {
            if (checkHit.transform.name == "block" + nameCnt.ToString())
            {
                movePos += Vector3.up * -1;
                ArrayCheck(movePos);
            }
            else
            {
                nameCnt = 1;
                return;
            }
        }
        else
        {
            nameCnt = 1;
            return;
        }
    }
}
