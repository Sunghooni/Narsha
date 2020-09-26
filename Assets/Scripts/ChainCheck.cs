using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCheck : MonoBehaviour
{
    RaycastHit hit;
    private bool canMove;
    private int nameCnt = 1;
    private int maxCnt = 3;
    void Start()
    {
        //int i = 1;
        //Debug.Log("block" + i.ToString());
    }

    void Update()
    {
        
    }

    void ArrayCheck(GameObject me)
    {
        if(nameCnt == maxCnt)
        {
            Debug.Log("Finished");
            return;
        }

        nameCnt += 1;
        
        Vector3 movePos = me.transform.position;
        movePos += Vector3.right * 5;
        movePos += Vector3.up * 5;

        if (Physics.Raycast(movePos, Vector3.down, out hit, 4.7f))
        {
            if (hit.transform.name == "block" + nameCnt.ToString())
                ArrayCheck(hit.transform.gameObject);
            else
                return;
        }
        return;
    }
}
