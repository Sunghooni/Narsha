using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlOptionUI : MonoBehaviour
{

    public void WASD_Clicked()
    {
        OptionValues.GetOptionValue().isControlKey = true;
    }

    public void Direction_Clicked()
    {
        OptionValues.GetOptionValue().isControlKey = false;
    }

    public void Full_Clicked()
    {
        OptionValues.GetOptionValue().isScreenMode = true;
    }

    public void Window_Clicked()
    {
        OptionValues.GetOptionValue().isScreenMode = true;
    }

    public void FHD_Clicked()
    {
        OptionValues.GetOptionValue().WindowSizeRow = 1920;
        OptionValues.GetOptionValue().WindowSizeCol = 1080;
    }

    public void HDPlus_Clicked()
    {
        OptionValues.GetOptionValue().WindowSizeRow = 1600;
        OptionValues.GetOptionValue().WindowSizeCol = 900;
    }

    public void HD_Clicked()
    {
        OptionValues.GetOptionValue().WindowSizeRow = 1280;
        OptionValues.GetOptionValue().WindowSizeCol = 720;
    }
}
