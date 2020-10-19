using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class StaticObject : MonoBehaviour
{
    private static StaticObject instance;
    private const String ObjectName = "StaticObject";
        
    public static StaticObject GetInstance()
    {
        if(instance == null)
        {
            instance = GameObject.FindObjectOfType<StaticObject>();
            
            if(instance == null)
            {
                instance = new GameObject(ObjectName).AddComponent<StaticObject>();
            }
        }

        return instance;
    }
}
