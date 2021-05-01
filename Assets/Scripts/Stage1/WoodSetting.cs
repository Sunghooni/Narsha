using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSetting : MonoBehaviour
{
    Transform WoodTransform;
    AudioSource WaterSound;
    public bool isEnd = false;

    private void Awake()
    {
        WoodTransform = GetComponent<Transform>();

        if (this.gameObject.name.Equals("RoundWood"))
        {
            WaterSound = this.gameObject.GetComponent<AudioSource>();
        }
    }

    private void FixedUpdate()
    {
        if (WoodTransform.position.y >= 0.75f)
        {
            MoveDown();
        }
        else
        {
            if (this.gameObject.name.Equals("RoundWood"))
            {
                WaterSound.enabled = true;
            }
        }
    }

    private void MoveDown()
    {
        transform.Translate(-Vector3.right * 5 * Time.deltaTime);
    }
}
