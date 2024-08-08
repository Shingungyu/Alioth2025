using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void NewGame()// 새로하기 버튼 실행 함수
    {
        SceneManager.LoadScene("Main1"); // Main1 씬 실행
    }
    public void ContinueGame() // 이어하기 버튼 실행 함수
    {
        SceneManager.LoadScene("Continue"); // Continue 씬 실행 
    }
    public void Option()//설정 버튼 실행 함수
    {
        SceneManager.LoadScene("Option"); // Option 씬 실행 
    }
    public void Exit()//설정 버튼 실행 함수
    {
        SceneManager.LoadScene("Lobby"); // Lobby 씬 실행 
    }
}
