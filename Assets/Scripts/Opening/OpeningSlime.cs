using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OpeningSlime : MonoBehaviour //todo  : 슬라임이 자동으로 이동하면서 NTNT밀기
{
    public GameObject player;
    private int moveCnt = 0;
    private float alpha = 1.0f;
    Renderer renderer;
    
    private void Start()
    {
        renderer = player.GetComponent<Renderer>();
        Invoke(nameof(MoveSlime), 0.3f);
    }


    private void MoveSlime()
    {
        if (moveCnt < 12)
        {
            transform.Translate(new Vector3(0.8f, 0.0f, 0.0f));
            moveCnt++;

            FindObjectOfType<AudioManager>().PlaySounds("BasicMove");
            Invoke(nameof(MoveSlime), 0.3f);
        }
        else
        {
            StartCoroutine(nameof(FadeOut));
        }
    }

    IEnumerator FadeOut()
    {
        while (alpha > 0)
        {
            alpha -= 0.05f;
            Color c = renderer.material.color;
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.04f);
        }
    }
}

