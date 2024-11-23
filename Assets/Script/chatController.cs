using RainbowArt.CleanFlatUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chatController : MonoBehaviour
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

    IEnumerator TextPractice() {

        yield return StartCoroutine(NormalChat("Alioth", "........."));
        yield return StartCoroutine(NormalChat("Alioth", "뭔가 이상해..."));
        yield return StartCoroutine(NormalChat("Alioth", "메그레즈의 행성은 분명 이런 모양새가 아니었는데.."));
        yield return StartCoroutine(NormalChat("Alioth", "아까보다 오히려 더 추워진 것 같아."));
        yield return StartCoroutine(NormalChat("Alioth", "정신차리자. 앞으로 3명만 더 구하면 되는거야. 힘내자."));
        Time.timeScale = 1f;
        Canvas.SetActive(false);
    }
}
