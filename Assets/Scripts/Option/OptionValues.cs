using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class OptionValues
{

    private int _Volume = 100;
    private bool _isControlKey = true; //True : WASD, False : 방향키
    private bool _isScreenMode = true; //True : Full, False : Window
    private int _WindowSizeRow = 1920; //해상도 가로 크기
    private int _WindowSizeCol = 1080; //해상도 세로 크기

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

    public bool isScreenMode
    {
        set { _isScreenMode = value; }
        get { return _isScreenMode; }
    }

    public int WindowSizeRow
    {
        set { _WindowSizeRow = value; }
        get { return _WindowSizeRow; }
    }

    public int WindowSizeCol
    {
        set { _WindowSizeCol = value; }
        get { return _WindowSizeCol; }
    }

    static OptionValues optionvalue = new OptionValues();

    public static OptionValues GetOptionValue()
    {
        if (optionvalue == null)
            optionvalue = new OptionValues();
        return optionvalue;
    }
}
