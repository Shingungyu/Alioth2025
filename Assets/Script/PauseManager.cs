using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject optionsCanvas; // 옵션 UI 캔버스
    private bool isPaused = false;


   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }


    }
    public void TogglePause()
    {
        isPaused = !isPaused; // 상태 반전

        if (isPaused)
        {
            Time.timeScale = 0f; // 게임 일시정지
            optionsCanvas.SetActive(true); // 옵션 창 활성화
        }
        else
        {
            Time.timeScale = 1f; // 게임 재개
            optionsCanvas.SetActive(false); // 옵션 창 비활성화
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Lobby"); // 메인 화면 씬 이름으로 로드
    }
}

