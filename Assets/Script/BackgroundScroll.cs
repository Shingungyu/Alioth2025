using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    public Image background;
    public float backgroundSpeed = 0.1f;

    Vector2 backgroundScrollOffset = Vector2.zero;

    void Start()
    {
        // SpriteRenderer�� ��������
        background = transform.Find("Desertruins_Dot").GetComponent<Image>();

        // background�� ���� ��� ���� �α� ���
        if (background == null)
        {
            Debug.LogError("Background SpriteRenderer�� ã�� �� �����ϴ�.");
        }
    }

    void Update()
    {
        if (background != null)
        {
            ScrollBackgroundImage();
        }
    }

    private void ScrollBackgroundImage()
    {
        backgroundScrollOffset.x += (backgroundSpeed * Time.deltaTime);

        // SpriteRenderer�� material�� �̿��� �ؽ�ó ������ ����
        background.material.mainTextureOffset = backgroundScrollOffset;
    }
}
