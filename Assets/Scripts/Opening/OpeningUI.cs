using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningUI : MonoBehaviour
{
    RectTransform NTNT;
    int i = 0;
    int j = 0;
    // Start is called before the first frame update
    public void Start()
    {
        NTNT = FindObjectOfType<OpeningUI>().GetComponent<RectTransform>();

          
        InvokeRepeating("moveUI", 0.3f, 0.3f);       
    }


    void moveUI()
    {   
        Vector2 aPos = NTNT.position;

        if (i < 12)
        {
            aPos.x = aPos.x -= 100;

            NTNT.position = aPos;

            i++;
        }
        else
        {
            Debug.Log("moveend");
            InvokeRepeating("godown", 0.8f, 0.3f);      
        }
    }

    void godown()
    {
        if (j < 10)
        {
            Debug.Log("godown");

            Vector2 aPos = NTNT.position;

            aPos.y -= 10;

            NTNT.position = aPos;

            j++;          
        }
        else
            CancelInvoke();
    }
}
