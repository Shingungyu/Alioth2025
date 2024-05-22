using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void NewGame()//새로하기 버튼 실행 함수
    {
        //NEW 에서 Main로 임의로 설정하였습니다.
        SceneManager.LoadScene("Main");//Main1 씬 실행
    }
    public void ContinueGame()//이어하기 버튼 실행 함수
    {
        SceneManager.LoadScene("Continue"); ;//Continue 씬 실행 
    }
    public void Option()//설정 버튼 실행 함수
    {
        SceneManager.LoadScene("Option"); ;//Option 씬 실행 
    }
    public void Exit()//설정 버튼 실행 함수
    {
        SceneManager.LoadScene("SampleScene"); ;//SampleScene 씬 실행 
    }
}
