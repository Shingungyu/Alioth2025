using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{

    public string stage1_1;

    public void NewGame()// 새로하기 버튼 실행 함수
    {
        SceneManager.LoadScene(stage1_1); // Stage1-1 씬 실행
    }
    public void ContinueGame() // 이어하기 버튼 실행 함수
    {
        SceneManager.LoadScene("Continue"); // Continue 씬 실행 
    }
    public void Option()//설정 버튼 실행 함수
    {
        SceneManager.LoadScene("Option"); // Option 씬 실행 
    }
}
