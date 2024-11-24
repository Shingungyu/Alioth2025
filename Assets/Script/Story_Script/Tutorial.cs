using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Text ChatText;
    public Text CharacterName;

    public string writerText = "";

    GameObject Canvas;

    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        StartCoroutine(TextPractice());
        Time.timeScale = 0f;
    }


    IEnumerator NormalChat(string narrator, string narration)
    {
        int a = 0;
        CharacterName.text = narrator;
        writerText = "";

        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }

        while (true)
        {
            if (Input.GetKeyDown("z"))
            {
                break;
            }
            yield return null;
        }

    }

    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("관리자", "해당 맵은 튜토리얼 맵입니다!"));
        yield return StartCoroutine(NormalChat("관리자", "게임의 조작법을 익히시고 천천히 플레이해보세요."));
        Time.timeScale = 1f;
        Canvas.SetActive(false);  // 대사 출력 후 캔버스 비활성화
    }
}
