using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class OptionValues
{

    private int _Volume = 100;
    private static string hzControlKey = "HZ_WASD";
    private static string vtControlKey = "VT_WASD";

    public int Volume
    {
        set { _Volume = value; }
        get { return _Volume; }
    }

    static OptionValues optionvalue = new OptionValues();

    public static OptionValues GetOptionValue()
    {
        if (optionvalue == null)
            optionvalue = new OptionValues();
        return optionvalue;
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
