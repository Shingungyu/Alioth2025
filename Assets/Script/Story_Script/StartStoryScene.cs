using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartStoryScene : MonoBehaviour
{
    public float scrollSpeed = 100f;        // 기본 스크롤 속도
    public float boostMultiplier = 2f;    // 스페이스 바를 누를 때의 배속
    private RectTransform textRect;       // 텍스트의 RectTransform

    void Start()
    {
        textRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        // 기본 스크롤 속도
        float currentSpeed = scrollSpeed;

        // 스페이스 바를 누르면 스크롤 속도를 증가
        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed *= boostMultiplier;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Stg1-1");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("Lobby");
        }

        // 텍스트를 위로 이동
        textRect.anchoredPosition += Vector2.up * currentSpeed * Time.deltaTime;

        // 텍스트가 화면 밖으로 넘어갔을 때 동작 (필요에 따라 수정)
        if (textRect.anchoredPosition.y > 1000f) // 적절한 값으로 조정
        {
            // 예: 다음 씬으로 전환
            // UnityEngine.SceneManagement.SceneManager.LoadScene("NextSceneName");
        }
    }

}
