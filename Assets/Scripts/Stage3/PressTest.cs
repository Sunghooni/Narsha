using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressTest : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject == player)
        {
            other.gameObject.transform.localScale -= new Vector3(0, 0, 80);
        }
    }
}
