using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    void GameEnd()
    {
        SceneManager.LoadScene("Main");
    }

    void GameContinue()
    {

    }
}
