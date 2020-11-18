using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class OptionValues
{

    private static float _Volume = 1;
    private static string hzControlKey = "HZ_WASD";
    private static string vtControlKey = "VT_WASD";

    public static void SetVolume(float value)
    {
        _Volume = value;
        //Debug.Log(_Volume);
    }

    public static float GetVolume()
    {
        return _Volume;
    }

    public static void SetControlKey(string hzValue, string vtValue)
    {
        hzControlKey = hzValue;
        vtControlKey = vtValue;
    }

    public static string GetHzKey()
    {
        return hzControlKey;
    }

    public static string GetVtKey()
    {
        return vtControlKey;
    }
}
