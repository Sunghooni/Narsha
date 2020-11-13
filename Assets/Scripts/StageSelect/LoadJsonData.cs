using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class StageClearInfo
{
    public int ClearNumber;

    public StageClearInfo(int ClearNum)
    {
        ClearNumber = ClearNum;
    }
}

public class LoadJsonData : MonoBehaviour
{
    public List<StageClearInfo> ClearNum = new List<StageClearInfo>();
    string JsonPath, JsonData;
    FileInfo isExists;


    private void Awake()
    {
        JsonPath = Application.dataPath + "/Resources/StageClear.json";
        isExists = new FileInfo(JsonPath);
    }

    private void Start()
    {
        if (!isExists.Exists)
            MakeJsonFile();
    }

    private void Update()
    {
        Debug.Log(JsonData);
    }

    void MakeJsonFile()
    {
        ClearNum.Add(new StageClearInfo(0));
        JsonData = JsonMapper.ToJson(ClearNum);

        File.WriteAllText(JsonPath, JsonData.ToString());
    }
}
