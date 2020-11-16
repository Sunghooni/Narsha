using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Optionclick : MonoBehaviour
{
      public void onclickoption()
    {
        SceneManager.LoadScene("Option", LoadSceneMode.Additive);
    }
}
