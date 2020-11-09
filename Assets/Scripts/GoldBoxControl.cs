using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBoxControl : MonoBehaviour
{
    public GameObject GoldBoxPart, GoldBox, ClearPanel;
    Rigidbody GoldBoxRigidBody;
    bool isPlayer = false;
    public bool Clear = false;

    private void Awake()
    {
        GoldBoxRigidBody = GoldBox.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(isPlayer)
        {
            GoldBoxAnim();
            Invoke("ShowClearPanel", 0.5f);
        }
        Debug.Log(GoldBoxPart.transform.rotation.z);
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

    private void ShowClearPanel()
    {
        ClearPanel.SetActive(true);
    }
}
