using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GoldBox_Stage2 : MonoBehaviour
{
    public ClearCheck_Stage2 clearCheck;
    public Camera Camera;
    public GameObject goldBox;
    public GameObject topPart;
    public GameObject leftCover;
    public GameObject rightCover;
    public bool winCheck = false;

    private bool isEnter = false;
    private bool isShowed = false;
    private float cameraDelay = 0f;

    private void FixedUpdate()
    {
        if (clearCheck.templeCheck)
        {
            CameraCtrl();
            ShowBox();
        }
        if(isEnter)
        {
            GoldBoxAnim();
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
                clearCheck.lengthNum = 0;
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag.Equals("Player"))
        {
            isEnter = true;
        }
    }
}
