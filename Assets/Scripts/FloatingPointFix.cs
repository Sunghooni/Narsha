using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPointFix : MonoBehaviour
{
    private Vector3 colliderCenter;
    private Vector3 colliderSize;

    private void Awake()
    {
        colliderCenter = new Vector3(-0.0035f, -0.0035f, 0.001f);
        colliderSize = new Vector3(0.009f, 0.009f, 0.005f);

        BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
        boxCollider.center = colliderCenter;
        boxCollider.size = colliderSize;
    }
}
