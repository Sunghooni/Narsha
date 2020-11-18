using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class GoldBox_Stage2 : MonoBehaviour
{
    public ClearCheck_Stage2 clearCheck;
    public Camera Camera;
    public GameObject goldBox;
    public GameObject topPart;
    public GameObject leftCover;
    public GameObject rightCover;
    public GameObject MissionText;
    public GameObject AudioManager;
    public bool winCheck = false;

    private bool isEnter = false;
    private bool isShowed = false;
    private float cameraDelay = 0f;
    private bool clearEft = true;

    private void FixedUpdate()
    {
        if (clearCheck.templeCheck)
        {
            Invoke("CameraCtrl", 0.5f);
            Invoke("ShowBox", 0.5f);
        }
        if(isEnter)
        {
            GoldBoxAnim();
            Invoke("ShowClearPanel", 1.0f);
        }
    }

    private void CameraCtrl()
    {
        if (isShowed)
            Camera.depth = 0;
        else
        {
            Camera.depth = -2;
        }
    }

    private void ShowBox()
    {
        if (leftCover.transform.position.x > -3.75f)
        {
            leftCover.transform.Translate(Vector3.left * Time.deltaTime);
            rightCover.transform.Translate(Vector3.right * Time.deltaTime);
        }
        else if(goldBox.transform.position.y <= 1.5f)
        {
            goldBox.transform.Translate(Vector3.up * Time.deltaTime * 1.5f);
        }
        else
        {
            if (cameraDelay > 0.5f)
            {
                StartCoroutine("UpDelay");
                isShowed = true;
            }

            cameraDelay += Time.deltaTime;
        }
    }

    private void GoldBoxAnim()
    {
        if (topPart.transform.rotation.x < 0.4f)
        {
            topPart.transform.Rotate(Vector3.up * 1000.0f * Time.deltaTime);
        }
        else
        {
            winCheck = true;
        }
    }

    IEnumerator UpDelay()
    {
        yield return new WaitForSeconds(0.5f);
        clearCheck.lengthNum = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag.Equals("Player"))
        {
            isEnter = true;
        }
    }

    private void ShowClearPanel()
    {
        MissionText.GetComponent<Text>().color = Color.green;
        if(clearEft)
        {
            AudioManager.GetComponent<AudioManager>().PlaySounds("CodeComplete");
            clearEft = false;
        }
        FindObjectOfType<InGameUIManager>().Clear();
    }
}
