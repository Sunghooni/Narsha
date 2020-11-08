using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSetting : MonoBehaviour
{
    Transform WoodTransform;
    Rigidbody WoodRigidBody;

    private void Awake()
    {
        WoodTransform = GetComponent<Transform>();
        WoodRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (WoodTransform.position.y <= 1.1f)
            WoodRigidBody.useGravity = false;
    }
}
