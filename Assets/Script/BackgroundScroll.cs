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
        // SpriteRenderer를 가져오기
        background = transform.Find("Desertruins_Dot").GetComponent<Image>();

        // background가 없을 경우 에러 로그 출력
        if (background == null)
        {
            Debug.LogError("Background SpriteRenderer를 찾을 수 없습니다.");
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

        // SpriteRenderer의 material을 이용해 텍스처 오프셋 설정
        background.material.mainTextureOffset = backgroundScrollOffset;
    }
}
