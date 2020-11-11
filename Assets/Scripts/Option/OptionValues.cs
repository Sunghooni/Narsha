using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class OptionValues
{

    private int _Volume = 100;
    private bool _isControlKey = true; //True : WASD, False : 방향키

    public int Volume
    {
        set { _Volume = value; }
        get { return _Volume; }
    }

    public bool isControlKey
    {
        set { _isControlKey = value; }
        get { return _isControlKey; }
    }

    static OptionValues optionvalue = new OptionValues();

    public static OptionValues GetOptionValue()
    {
        if (optionvalue == null)
            optionvalue = new OptionValues();
        return optionvalue;
    }
}
