using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StaticObject 
{
    private static GameObject instance;
    private const String ObjectName = "StaticObject";
        
    public static GameObject GetInstance()
    {
        if(instance == null)
        {
            instance = GameObject.Find(ObjectName);
            
            if(instance == null)
            {
                instance = new GameObject(ObjectName);
            }
        }

        return instance;
    }
}
