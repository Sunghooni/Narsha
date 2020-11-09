using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    private void FixedUpdate()
    {
        var pos = player.transform.position;
        Vector3 target = new Vector3(pos.x, pos.y + 5.6f, pos.z - 3.5f);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target, Time.deltaTime);
    }
}
