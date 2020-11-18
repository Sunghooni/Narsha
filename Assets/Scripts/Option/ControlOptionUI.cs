using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlOptionUI : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        GameObject.Find("TXT_Volume").GetComponent<TextMeshProUGUI>().text = OptionValues.GetOptionValue().Volume.ToString();
        slider.value = OptionValues.GetOptionValue().Volume;
        SetControlKeyColor();
    }

    public void WASD_Clicked()
    {
        OptionValues.SetControlKey("HZ_WASD", "VT_WASD");
        SetControlKeyColor();
    }

    public void Direction_Clicked()
    {
        OptionValues.SetControlKey("HZ_DIR", "VT_DIR");
        SetControlKeyColor();
    }

    public void SetControlKeyColor()
    {
        ColorBlock WASD_CBlock = GameObject.Find("BTN_WASD").GetComponent<Button>().colors;
        ColorBlock Direction_CBlock = GameObject.Find("BTN_Direction").GetComponent<Button>().colors;
        if ("HZ_WASD".Equals(OptionValues.GetHzKey()))
        {
            WASD_CBlock.normalColor = Color.green;
            WASD_CBlock.highlightedColor = Color.green;
            Direction_CBlock.normalColor = Color.white;
            Direction_CBlock.highlightedColor = Color.white;
        }
        else
        {
            WASD_CBlock.normalColor = Color.white;
            WASD_CBlock.highlightedColor = Color.white;
            Direction_CBlock.normalColor = Color.green;
            Direction_CBlock.highlightedColor = Color.green;
        }
        GameObject.Find("BTN_WASD").GetComponent<Button>().colors = WASD_CBlock;
        GameObject.Find("BTN_Direction").GetComponent<Button>().colors = Direction_CBlock;
    }

    public void Full_Clicked()
    {
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    }

    public void Window_Clicked()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }

    public void FHD_Clicked()
    {
        SettingResolution(1920, 1080);
    }

    public void HDPlus_Clicked()
    {
        SettingResolution(1600, 900);
    }

    public void HD_Clicked()
    {
        SettingResolution(1280, 720);
    }

    private void SettingResolution(int Row, int Col)
    {
        Screen.SetResolution(Row, Col, Screen.fullScreenMode);
    }

    public void UpdateVolum()
    {
        GameObject.Find("TXT_Volume").GetComponent<TextMeshProUGUI>().text = (slider.value).ToString();
        OptionValues.GetOptionValue().Volume = Int32.Parse((slider.value).ToString());
    }

    public void closeclick()
    {
        SceneManager.UnloadSceneAsync("Option");
        Optionclick.isclicked = false;
    }
}
