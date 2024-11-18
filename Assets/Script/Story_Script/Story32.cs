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
        Canvas.SetActive(false);  // ���� �� ĵ���� ��Ȱ��ȭ
        StartCoroutine(ActivateCanvasAfterDelay(4.2f));  // 3.2�� �� ĵ���� Ȱ��ȭ
    }

    IEnumerator ActivateCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Canvas.SetActive(true);  // 3.2�� �� ĵ���� Ȱ��ȭ
        StartCoroutine(TextPractice());  // ĵ������ Ȱ��ȭ�� �� ��� ��� ����
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
        yield return StartCoroutine(NormalChat("Alioth", "��� ������?"));
        yield return StartCoroutine(NormalChat("Alioth", "�������� ������ �Ӹ��� �� ���ʹ� �ǰ�.."));
        yield return StartCoroutine(NormalChat("Alioth", "�̷����ϼ��� ������ ��������"));
        yield return StartCoroutine(NormalChat("Alioth", "��θ� �츮���� �����̾�. ������ ������."));

        Canvas.SetActive(false);  // ��� ��� �� ĵ���� ��Ȱ��ȭ
    }
}