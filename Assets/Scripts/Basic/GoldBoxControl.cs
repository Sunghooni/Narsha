using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldBoxControl : MonoBehaviour
{
    public GameObject GoldBoxPart, GoldBox, ClearPanel, MissionText;
    public bool Clear = false;
    private bool isPlayer = false;

    Rigidbody GoldBoxRigidBody;
    InGameUIManager IGUI;

    private void Awake()
    {
        GoldBoxRigidBody = GoldBox.GetComponent<Rigidbody>();
        IGUI = FindObjectOfType<InGameUIManager>().GetComponent<InGameUIManager>();
    }

    private void Update()
    {
        float showClearPanelDelay = 0.15f;

        if(isPlayer)
        {
            MissionText.GetComponent<Text>().color = Color.green;

            GoldBoxAnim();
            Invoke(nameof(ShowClearPanel), showClearPanelDelay);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        float boxOpenForce = 1.5f;

        if (other.gameObject.CompareTag("Player"))
        {
            if (!isPlayer)
            {
                GoldBoxRigidBody.AddForce(Vector3.up * boxOpenForce, ForceMode.Impulse);
                FindObjectOfType<AudioManager>().PlaySounds("CodeComplete");
            }
            isPlayer = true;
        }
    }

    private void GoldBoxAnim()
    {
        float maxOpenRot = -0.65f;
        float openSpeed = 1000f;

        if (isPlayer && GoldBoxPart.transform.rotation.z >= maxOpenRot)
        {
            GoldBoxPart.transform.Rotate(-Vector3.forward * openSpeed * Time.deltaTime);
        }
    }

    private void ShowClearPanel()
    {
        IGUI.Clear();
    }
}
