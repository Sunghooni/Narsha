using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class GoldBox_Stage2 : MonoBehaviour
{
    public ClearCheck_Stage2 clearCheck;
    public Camera Camera;
    public InGameUIManager IGUI;
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
        float templeCheckDelay = 0.5f;
        float enterDelay = 0.3f;

        if (clearCheck.templeCheck)
        {
            Invoke(nameof(CameraCtrl), templeCheckDelay);
            Invoke(nameof(ShowBox), templeCheckDelay);
        }
        if(isEnter)
        {
            GoldBoxAnim();
            Invoke(nameof(ShowClearPanel), enterDelay);
        }
    }

    private void CameraCtrl()
    {
        if (isShowed)
        {
            Camera.depth = 0;
        }
        else
        {
            Camera.depth = -2;
        }
    }

    private void ShowBox()
    {
        float coverOpenedX = -3.75f;
        float boxToHeight = 1.5f;
        float boxShowSpeed = 1.5f;

        if (leftCover.transform.position.x > coverOpenedX)
        {
            leftCover.transform.Translate(Vector3.left * Time.deltaTime);
            rightCover.transform.Translate(Vector3.right * Time.deltaTime);
        }
        else if (goldBox.transform.position.y <= boxToHeight)
        {
            goldBox.transform.Translate(Vector3.up * Time.deltaTime * boxShowSpeed);
        }
        else
        {
            if (cameraDelay > 0.5f)
            {
                StartCoroutine(nameof(UpDelay));
                isShowed = true;
            }

            cameraDelay += Time.deltaTime;
        }
    }

    private void GoldBoxAnim()
    {
        float boxOpenedRotX = 0.4f;
        float boxOpenSpeed = 1000f;

        if (topPart.transform.rotation.x < boxOpenedRotX)
        {
            topPart.transform.Rotate(Vector3.up * boxOpenSpeed * Time.deltaTime);
        }
        else
        {
            winCheck = true;
        }
    }

    IEnumerator UpDelay()
    {
        float delayTime = 0.5f;

        yield return new WaitForSeconds(delayTime);
        clearCheck.lengthNum = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isEnter = true;
        }
    }

    private void ShowClearPanel()
    {
        if (clearEft)
        {
            AudioManager.GetComponent<AudioManager>().PlaySounds("CodeComplete");
            clearEft = false;
        }

        MissionText.GetComponent<Text>().color = Color.green;
        IGUI.Clear();
    }
}
