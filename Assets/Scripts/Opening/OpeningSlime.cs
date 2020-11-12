using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OpeningSlime : MonoBehaviour //todo  : 슬라임이 자동으로 이동하면서 NTNT밀기
{
    public GameObject player;

    int i = 0;

    float alpha = 1.0f;

    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = player.GetComponent<Renderer>();

        Invoke("moveslime", 0.3f);
    }


    void moveslime()
    {
        if (i < 12)
        {
            transform.Translate(new Vector3(0.8f, 0.0f, 0.0f));

            i++;

            Invoke("moveslime", 0.3f);
        }
        else {
            Debug.Log("moveend");
            StartCoroutine("FadeOut");
        }
    }

    IEnumerator FadeOut()
    {
        while (alpha > 0)
        {
            Debug.Log("fadeout");
            alpha -= 0.05f;
            Color c = renderer.material.color;
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.04f);
        }
        Debug.Log("fadeout end");
    }
}

