using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresserMovement : MonoBehaviour
{
    public bool startAct = false;

    private Vector3 rotatePos;

    private void Awake()
    {
        rotatePos = gameObject.transform.position;
    }

    private void Update()
    {
        if(startAct)
        {
            StartCoroutine("PressDown");
        }
    }

    IEnumerator PressDown()
    {
        yield return new WaitForFixedUpdate();
    }

    IEnumerator PressUp()
    {
        yield return new WaitForFixedUpdate();
    }
}
