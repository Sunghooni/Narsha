using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSetting : MonoBehaviour
{
    Transform WoodTransform;

    private void Awake()
    {
        WoodTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if(WoodTransform.position.y >= 0.75f)
            MoveDown();
    }

    void MoveDown()
    {
        transform.Translate(-Vector3.right * 5 * Time.deltaTime);
    }
}
