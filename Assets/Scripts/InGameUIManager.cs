using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    bool isPause = false;
    public GameObject PausePanel;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!PausePanel.active)
                PausePanel.SetActive(true);
            else
                PausePanel.SetActive(false);
        }
    }

    public void BackToStage()
    {
        SceneManager.LoadScene("Stage");
    }
}
