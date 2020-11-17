using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResetJSON : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F2))
        {
            File.WriteAllText(Application.dataPath + "/Resources/StageClear.json", "0");
        }
    }
}
