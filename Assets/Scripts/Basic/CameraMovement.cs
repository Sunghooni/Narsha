using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;

    private void FixedUpdate()
    {
        var pos = target.transform.position;
        Vector3 targetPos = new Vector3(pos.x, pos.y + 5.6f, pos.z - 3.5f);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPos, 5 * Time.deltaTime);
    }
}
