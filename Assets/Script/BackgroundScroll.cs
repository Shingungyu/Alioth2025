using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    public Image background;  // background ������Ʈ�� Image ������Ʈ�� ����
    private float backgroundSpeed = 0.05f;  // ��ũ�� �ӵ�

    private Vector2 backgroundScrollOffset = Vector2.zero;

    void Start()
    {
        // background ������Ʈ�� ������� �ʾ��� ���, �ڽ� ������Ʈ���� �����ɴϴ�.
        if (background == null && transform.childCount > 0)
        {
            background = transform.GetChild(0).GetComponent<Image>();

            if (background == null)
            {
                Debug.LogError("�ڽ� ������Ʈ�� Image ������Ʈ�� �����ϴ�.");
                return;
            }

            // Material�� �ν��Ͻ�ȭ�Ͽ� �ٸ� ������Ʈ�� �������� �ʵ��� �մϴ�.
            background.material = new Material(background.material);
        }
        else if (background == null)
        {
            Debug.LogError("background ������Ʈ�� �ڽ��� �����ϴ�.");
            return;
        }

        Debug.Log("background ������Ʈ�� �ڽ� ����: " + transform.childCount);
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
        // Offset ���� �ݺ��Ͽ� ������ ���� ������ ��ũ�� ȿ���� ����ϴ�.
        backgroundScrollOffset.x = Mathf.Repeat(backgroundScrollOffset.x + (backgroundSpeed * Time.deltaTime), 1);
        background.material.mainTextureOffset = backgroundScrollOffset;
    }
}

/*private void ScrollBackgroundImage()
    {
        backgroundScrollOffset.x += (backgroundSpeed * Time.deltaTime);

        // �ν��Ͻ�ȭ�� ��Ƽ������ mainTextureOffset�� �����մϴ�.
        background.material.mainTextureOffset = backgroundScrollOffset;
    }*/
