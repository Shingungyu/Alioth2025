using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScaler : MonoBehaviour
{
    public Image background;

    void Start()
    {
        background = GetComponent<Image>();

        if (background == null)
        {
            Debug.LogError("Background Image�� ã�� �� �����ϴ�.");
            return;
        }

        // ��� �̹����� ȭ���� ���� ä�쵵�� ����
        ScaleBackground();
    }

    void ScaleBackground()
    {
        RectTransform rt = background.GetComponent<RectTransform>();

        // ī�޶��� ������ ���մϴ�
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float imageAspect = background.sprite.bounds.size.x / background.sprite.bounds.size.y;

        if (screenAspect > imageAspect)
        {
            // ȭ���� �̹������� ������ ���̿� ���߰� �ʺ� �����մϴ�.
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.x / imageAspect);
        }
        else
        {
            // ȭ���� �̹������� ��� �ʺ� ���߰� ���̸� �����մϴ�.
            rt.sizeDelta = new Vector2(rt.sizeDelta.y * imageAspect, rt.sizeDelta.y);
        }

        // ��Ŀ ���� (�̹����� �߾ӿ� ��ġ�ϵ���)
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.pivot = new Vector2(0.5f, 0.5f);
    }
}








