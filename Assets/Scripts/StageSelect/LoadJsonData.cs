using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StageClearInfo
{
    public int ID;
    public bool IsClear;

    public StageClearInfo(int id, bool isClear)
    {
        ID = id;
        IsClear = isClear;
    }
}

public class LoadJsonData : MonoBehaviour
{
    public List<StageClearInfo> StageList = new List<StageClearInfo>();
    string JsonPath, JsonData;


    private void Awake()
    {
        JsonPath = Application.dataPath + "/Resources/StageClear.json";
    }

    private void Start()
    {
        FileInfo isExists = new FileInfo(JsonPath);
        if (!isExists.Exists)
            MakeJsonFile();
    }

    private void Update()
    {
        Debug.Log(JsonData);
    }

    void MakeJsonFile()
    {
        StageList.Add(new StageClearInfo(0, false));
        StageList.Add(new StageClearInfo(1, false));
        StageList.Add(new StageClearInfo(2, false));
        StageList.Add(new StageClearInfo(3, false));
        StageList.Add(new StageClearInfo(4, false));
        StageList.Add(new StageClearInfo(5, false));

        JsonData = JsonUtility.ToJson(StageList);

        File.WriteAllText(JsonPath, JsonData.ToString());

    }
}
