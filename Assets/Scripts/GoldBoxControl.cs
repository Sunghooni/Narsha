using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBoxControl : MonoBehaviour
{
    public GameObject GoldBoxPart;
    bool isPlayer = false;

    private void Update()
    {
        if(isPlayer)
            GoldBoxPart.transform.Rotate(Vector3.up * 3.0f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("fhuwef");
            isPlayer = true;
        }
    }

    private void GoldBoxAnim()
    {

    }
}
