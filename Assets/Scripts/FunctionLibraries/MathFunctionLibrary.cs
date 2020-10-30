using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public sealed class MathFunctionLibrary
{
    public static float VectorToDegree(Vector2 vec)
    {
        Vector2 normalized = vec.normalized;
        float acos = Mathf.Acos(normalized.x) * Mathf.Rad2Deg;
        float sinSign = Mathf.Sign(vec.y);

        float degree = acos * sinSign;
        return degree;
    }

    public static float SnapByUnit(float rot, float unit)
    {
        return Mathf.Round(rot / unit) * unit;
    }
}
