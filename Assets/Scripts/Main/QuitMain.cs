using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMain : MonoBehaviour
{
    public void Quitclick()
    {
        
          UnityEditor.EditorApplication.isPlaying = false; //출시할땐 주석처리해서 내자 ㅇㅋ?

          Application.Quit(); // 어플리케이션 종료
    }
}
