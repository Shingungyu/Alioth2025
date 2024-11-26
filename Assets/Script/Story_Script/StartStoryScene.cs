using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartStoryScene : MonoBehaviour
{
    public float scrollSpeed = 100f;        // �⺻ ��ũ�� �ӵ�
    public float boostMultiplier = 2f;    // �����̽� �ٸ� ���� ���� ���
    private RectTransform textRect;       // �ؽ�Ʈ�� RectTransform

    void Start()
    {
        textRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        // �⺻ ��ũ�� �ӵ�
        float currentSpeed = scrollSpeed;

        // �����̽� �ٸ� ������ ��ũ�� �ӵ��� ����
        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed *= boostMultiplier;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Stg1-1");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("Lobby");
        }

        // �ؽ�Ʈ�� ���� �̵�
        textRect.anchoredPosition += Vector2.up * currentSpeed * Time.deltaTime;

        // �ؽ�Ʈ�� ȭ�� ������ �Ѿ�� �� ���� (�ʿ信 ���� ����)
        if (textRect.anchoredPosition.y > 1000f) // ������ ������ ����
        {
            // ��: ���� ������ ��ȯ
            // UnityEngine.SceneManagement.SceneManager.LoadScene("NextSceneName");
        }
    }

}
