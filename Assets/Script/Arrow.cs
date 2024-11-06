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
        // 현재 색상을 가져와서 알파 값만 수정합니다.
        Color color = spriteRenderer.color;
        color.a = Mathf.Clamp01(alpha); // alpha 값은 0~1 사이로 제한됩니다.
        spriteRenderer.color = color;
    }
}
