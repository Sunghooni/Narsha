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
    Color OpenNormalColor, OpenHighlightedColor, OpenPressedColor;
    public Color OffNormalColor, OffHighlighedColor, OffPressedColor;
    ColorBlock CurrentColor;


    private void Awake()
    {
        JsonPath = Application.dataPath + "/Resources/StageClear.json";
        JsonData = File.ReadAllText(JsonPath);
        OpenNormalColor = new Color(195 / 255f, 236 / 255f, 172 / 255f);
        OpenHighlightedColor = new Color(143 / 255f, 255 / 255f, 160 / 255f);
        OpenPressedColor = new Color(143 / 255f, 255 / 255f, 160 / 255f);

        OffNormalColor = new Color(115 / 225f, 115 / 225f, 115 / 225f);
        OffHighlighedColor = new Color(77 / 225f, 77 / 225f, 77 / 255f);
        OffPressedColor = new Color(77 / 225f, 77 / 225f, 77 / 255f);
    }

    private void Start()
    {
        for(int i = 0; i < StageButton.Length; i++)
        {
            CurrentColor = StageButton[i].colors;
            CurrentColor.normalColor = OffNormalColor;
            CurrentColor.highlightedColor = OffHighlighedColor;
            CurrentColor.pressedColor = OffPressedColor;
            StageButton[i].colors = CurrentColor;
        }
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
            CurrentColor.normalColor = OpenNormalColor;
            CurrentColor.highlightedColor = OpenHighlightedColor;
            CurrentColor.pressedColor = OpenPressedColor;
            StageButton[i].colors = CurrentColor;
        }
    }
}
