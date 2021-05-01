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
    private int i = 0;
    private int j = 0;
    private int scwidth;
    private int scheight;

    public void Awake()
    {
        scwidth = Screen.width;
        scheight = Screen.height;
        Screen.SetResolution(1920, 1080, Screen.fullScreenMode, 0);
    }

    public void Start()
    {
        color = Team.GetComponent<UnityEngine.UI.Text>().color;

        InvokeRepeating(nameof(MoveUI), 0.3f, 0.3f);       
    }

    private void MoveUI()
    {   
        if (i < 12)
        {
            NTNT.transform.Translate(new Vector3(-100f, 0.0f, 0.0f));
            i++;
        }
        else
        {
            InvokeRepeating(nameof(Godown), 0.8f, 0.01f);      
        }
    }

    private void Godown()
    {
        if (j < 100)
        {
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
