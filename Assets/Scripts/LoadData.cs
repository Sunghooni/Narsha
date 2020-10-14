using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Load();
    }

    void Load()
    {
        string jsonString = File.ReadAllText(Application.dataPath + "/Resources/StageClear.json");
        Debug.Log(jsonString);
    }   
}
