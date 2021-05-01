using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    private const float fixedY = 5.6f;
    private const float fixedZ = -3.5f;
    private const float playerFollowSpeed = 5f;

    private void FixedUpdate()
    {
        Vector3 pos = target.transform.position;
        Vector3 startPos = gameObject.transform.position;
        Vector3 targetPos = new Vector3(pos.x, pos.y + fixedY, pos.z + fixedZ);

        gameObject.transform.position = Vector3.Lerp(startPos, targetPos, playerFollowSpeed * Time.deltaTime);
    }
}
