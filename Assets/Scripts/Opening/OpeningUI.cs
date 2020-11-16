using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningUI : MonoBehaviour
{
    public GameObject NTNT;
    public GameObject Team;

    Color color;
    string t;
    int i = 0;
    int j = 0;
    int scwidth;
    int scheight;
    // Start is called before the first frame update
    public void Awake()
    {
        scwidth = Screen.width;
        scheight = Screen.height;
        Screen.SetResolution(1920, 1080, Screen.fullScreenMode, 0);
    }
    public void Start()
    {
        color = Team.GetComponent<UnityEngine.UI.Text>().color;

        InvokeRepeating("moveUI", 0.3f, 0.3f);       
    }


    void moveUI()
    {   

        if (i < 12)
        {

            NTNT.transform.Translate(new Vector3(-100f, 0.0f, 0.0f));
            i++;

        }
        else
        {
            Debug.Log("moveend");
            InvokeRepeating("godown", 0.8f, 0.01f);      
        }
    }

    void godown()
    {
        if (j < 100)
        {
            Debug.Log("godown");
            Debug.Log(color);

            NTNT.transform.Translate(new Vector3(0.0f, - 1f, 0.0f));
            if (j > 30)
            {
                color.a += 0.01f;
                Team.GetComponent<UnityEngine.UI.Text>().color = color;
            }
            j++;          
        }
        else
        {   
            CancelInvoke();
            Screen.SetResolution(scwidth, scheight, Screen.fullScreenMode);
            SceneManager.LoadScene("Main");
        }
    }
}
