using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject character;
    private Transform charPosition;
    private Transform arrowPosition;
    Vector2 charScreenPosition;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        charPosition = character.transform;
        arrowPosition = gameObject.transform;
    }

    void Update()
    {
        if (charScreenPosition.y >= 1080)
        {
            arrowPosition.position = new Vector2(charPosition.position.x, 4);
            SetAlpha(1);
        }
        else
        {
            SetAlpha(0);
        }
    }

    private void FixedUpdate()
    {
        charScreenPosition = Camera.main.WorldToScreenPoint(charPosition.position);
    }

    public void SetAlpha(float alpha)
    {
        // ���� ������ �����ͼ� ���� ���� �����մϴ�.
        Color color = spriteRenderer.color;
        color.a = Mathf.Clamp01(alpha); // alpha ���� 0~1 ���̷� ���ѵ˴ϴ�.
        spriteRenderer.color = color;
    }
}
