using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;

public class LoadJsonData : MonoBehaviour
{
    string JsonPath, JsonData;
    int StageNumber;
    public Button[] StageButton;
    Color OpenColor;
    ColorBlock CurrentColor;


    private void Awake()
    {
        JsonPath = Application.dataPath + "/Resources/StageClear.json";
        JsonData = File.ReadAllText(JsonPath);
        OpenColor = new Color(195 / 255f, 236 / 255f, 172 / 255f);
    }

    private void Update()
    {
        JsonData = Regex.Replace(JsonData, @"\D", "");
        StageNumber = int.Parse(JsonData);
        Debug.Log(StageNumber);
        ApplyStage();
    }

    private void ApplyStage()
    {
        for(int i = 0; i <= StageNumber; i++)
        {
            CurrentColor = StageButton[i].colors;
            CurrentColor.normalColor = OpenColor;
            StageButton[i].colors = CurrentColor;
        }
    }
}
