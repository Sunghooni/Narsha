using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldBoxControl : MonoBehaviour
{
    public GameObject GoldBoxPart, GoldBox, ClearPanel, MissionText;
    Rigidbody GoldBoxRigidBody;
    bool isPlayer = false;
    public bool Clear = false;
    InGameUIManager IGUI;

    private void Awake()
    {
        GoldBoxRigidBody = GoldBox.GetComponent<Rigidbody>();
        IGUI = FindObjectOfType<InGameUIManager>().GetComponent<InGameUIManager>();
    }

    private void Update()
    {
        if(isPlayer)
        {
            GoldBoxAnim();
            MissionText.GetComponent<Text>().color = Color.green;
            Invoke("ShowClearPanel", 1.0f);
        }
        //Debug.Log(GoldBoxPart.transform.rotation.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isPlayer)
            {
                GoldBoxRigidBody.AddForce(Vector3.up * 2.2f, ForceMode.Impulse);
                FindObjectOfType<AudioManager>().PlaySounds("CodeComplete");
            }
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
        IGUI.Clear();
    }
}
