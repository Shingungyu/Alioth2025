using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story31 : MonoBehaviour
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
        yield return StartCoroutine(NormalChat("Alioth", "����� ��ũ���� �༺�ΰŰ���."));
        yield return StartCoroutine(NormalChat("Alioth", "��ũ�ٸ� ���Ϸ�����."));
        Time.timeScale = 1f;
        Canvas.SetActive(false);  // ��� ��� �� ĵ���� ��Ȱ��ȭ
    }
}
