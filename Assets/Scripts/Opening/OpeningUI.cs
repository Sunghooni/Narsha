using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningUI : MonoBehaviour
{
    RectTransform NTNT;
    int i = 0;
    // Start is called before the first frame update
    public void Start()
    {
        NTNT = FindObjectOfType<OpeningUI>().GetComponent<RectTransform>();

          
        Invoke("moveUI", 0.3f);       
    }


    void moveUI()
    {
        if (i < 12)
        {
            Vector2 aPos = NTNT.position;

            aPos.x = aPos.x -= 100;

            NTNT.position = aPos;

            i++;

            Invoke("moveUI", 0.3f);
        }
    }
}
