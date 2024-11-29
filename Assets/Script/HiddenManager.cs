using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenManager : MonoBehaviour
{
    public GameObject HiddenCanvas; //숨겨진 캔버스
    private bool isPaused = false;


    


    public void TogglePause()
    {
        isPaused = !isPaused; // 상태 반전

        if (isPaused)
        {

            HiddenCanvas.SetActive(true); // 옵션 창 활성화
        }
        else
        {

            HiddenCanvas.SetActive(false); // 옵션 창 비활성화
        }
    }


}
