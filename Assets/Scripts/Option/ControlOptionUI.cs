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

    public void WASD_Clicked()
    {
        OptionValues.SetControlKey("HZ_WASD", "VT_WASD");
    }

    public void Direction_Clicked()
    {
        OptionValues.SetControlKey("HZ_DIR", "VT_DIR");
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

    public void UpdateVolumText()
    {
        GameObject.Find("TXT_Volume").GetComponent<TextMeshProUGUI>().text = (slider.value).ToString();
    }

    public void closeclick()
    {
        SceneManager.UnloadSceneAsync("Option");
        Optionclick.isclicked = false;
    }
}
