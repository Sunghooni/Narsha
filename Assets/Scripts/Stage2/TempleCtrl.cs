using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleCtrl : MonoBehaviour
{
    public AudioSource templeSound;
    public ClearCheck_Stage2 clearCheck;
    public int length;

    Vector3 toPos;
    Vector3 upPos;
    Vector3 downPos;

    public bool isMoving = false;
    private int preLength = 0;

    private void Awake()
    {
        upPos = gameObject.transform.position;
        downPos = upPos + Vector3.down;
    }

    private void FixedUpdate()
    {
        TempleSound();

        toPos = (length <= clearCheck.lengthNum) ? downPos : upPos;
        transform.position = Vector3.Lerp(transform.position, toPos, Time.deltaTime * 2);
    }

    private void TempleSound()
    {
        if(preLength != clearCheck.lengthNum && length == 1)
        {
            templeSound.Play();
            preLength = clearCheck.lengthNum;
        }
    }
}
