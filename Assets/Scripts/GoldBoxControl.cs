using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBoxControl : MonoBehaviour
{
    public GameObject GoldBoxPart, GoldBox;
    Rigidbody GoldBoxRigidBody;
    bool isPlayer = false;

    private void Awake()
    {
        GoldBoxRigidBody = GoldBox.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Debug.Log(GoldBoxPart.transform.rotation.z);
        GoldBoxAnim();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(!isPlayer)
                GoldBoxRigidBody.AddForce(Vector3.up * 1.5f, ForceMode.Impulse);
            Debug.Log("fhuwef");
            isPlayer = true;
        }
    }

    private void GoldBoxAnim()
    {
        if (isPlayer && GoldBoxPart.transform.rotation.z >= -0.65f)
        {
            GoldBoxPart.transform.Rotate(-Vector3.forward * 1000.0f * Time.deltaTime);
        }
    }
}
