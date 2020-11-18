using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class OptionValues
{

    private static int _Volume = 100;
    private static string hzControlKey = "HZ_WASD";
    private static string vtControlKey = "VT_WASD";

    public static void SetVolume(string value)
    {
        _Volume = int.Parse(value);
        //Debug.Log(_Volume);
    }

    public static int GetVolume()
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
