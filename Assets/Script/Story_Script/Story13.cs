using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story13 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("Alioth", "저건..."));
        yield return StartCoroutine(NormalChat("Alioth", "저게 두오의 힘인거같아."));
        yield return StartCoroutine(NormalChat("Alioth", "두오의 힘을 챙겨야해. 그래야 두오를 살릴 수 있어."));
        yield return StartCoroutine(NormalChat("Alioth", "저걸 가지고 더 나아가자."));
        Time.timeScale = 1f;
        Canvas.SetActive(false);  // 대사 출력 후 캔버스 비활성화
    }
}
