using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Story23 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("Alioth", "저기에 메라크의 힘이 있어."));
        yield return StartCoroutine(NormalChat("Alioth", "저 힘을 가지고 빠져나가야해."));
        Time.timeScale = 1f;
        Canvas.SetActive(false);  // 대사 출력 후 캔버스 비활성화
    }
}
