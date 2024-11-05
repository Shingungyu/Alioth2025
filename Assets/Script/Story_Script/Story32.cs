using RainbowArt.CleanFlatUI;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Story32 : MonoBehaviour
{
    public Text ChatText;
    public Text CharacterName;
    public string writerText = "";

    GameObject Canvas;

    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        Canvas.SetActive(false);  // 시작 시 캔버스 비활성화
        StartCoroutine(ActivateCanvasAfterDelay(4.2f));  // 3.2초 후 캔버스 활성화
    }

    IEnumerator ActivateCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Canvas.SetActive(true);  // 3.2초 후 캔버스 활성화
        StartCoroutine(TextPractice());  // 캔버스가 활성화된 후 대사 출력 시작
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
        yield return StartCoroutine(NormalChat("Alioth", "방금 뭐였지?"));
        yield return StartCoroutine(NormalChat("Alioth", "오랜만에 여정에 머리가 좀 아팠던 건가.."));
        yield return StartCoroutine(NormalChat("Alioth", "이럴때일수록 정신을 차려야해"));
        yield return StartCoroutine(NormalChat("Alioth", "모두를 살리려면 나뿐이야. 힘내고 가보자."));

        Canvas.SetActive(false);  // 대사 출력 후 캔버스 비활성화
    }
}