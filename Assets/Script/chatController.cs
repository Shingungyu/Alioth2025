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
        yield return StartCoroutine(NormalChat("Alioth", "���� �����?"));
        yield return StartCoroutine(NormalChat("Alioth", "�� �߿����� ������.."));
        yield return StartCoroutine(NormalChat("Alioth", "�ϴ� �� ���ư�����."));
        
        Canvas.SetActive(false);
    }
}
