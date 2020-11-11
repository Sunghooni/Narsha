using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBlock : MonoBehaviour
{
    public string code = null;
    Vector3 startPos;

    private void Awake()
    {
        startPos = gameObject.transform.position;
    }
}
