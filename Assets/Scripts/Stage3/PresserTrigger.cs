using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresserTrigger : MonoBehaviour
{
    public ClearCheck_Stage3 clearCheck;
    public GameObject[] pressers;

    private int tryCnt = 0;
    private string sign = null;

    private void Update()
    {
        if(sign != null && clearCheck.enterCheck)
        {
            PresserCtrl();
        }
        if(tryCnt != 0)
        {
            StartPress();
        }
    }

    private void PresserCtrl()
    {
        sign = clearCheck.sign;

        switch (sign)
        {
            case "<":
                tryCnt = 4;
                break;
            case "<=":
                tryCnt = 5;
                break;
            case "==":
                tryCnt = 0;
                break;
        }
    }

    private void StartPress()
    {
        for(int i = 0; i < tryCnt; i++)
        {
            pressers[i].GetComponent<PresserMovement>().startAct = true;
        }
    }
}
