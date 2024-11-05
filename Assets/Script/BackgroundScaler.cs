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
            Debug.LogError("Background Image를 찾을 수 없습니다.");
            return;
        }

        // 배경 이미지가 화면을 가득 채우도록 설정
        ScaleBackground();
    }

    void ScaleBackground()
    {
        RectTransform rt = background.GetComponent<RectTransform>();

        // 카메라의 비율을 구합니다
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float imageAspect = background.sprite.bounds.size.x / background.sprite.bounds.size.y;

        if (screenAspect > imageAspect)
        {
            // 화면이 이미지보다 넓으면 높이에 맞추고 너비를 조정합니다.
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.x / imageAspect);
        }
        else
        {
            // 화면이 이미지보다 길면 너비에 맞추고 높이를 조정합니다.
            rt.sizeDelta = new Vector2(rt.sizeDelta.y * imageAspect, rt.sizeDelta.y);
        }

        // 앵커 설정 (이미지가 중앙에 위치하도록)
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.pivot = new Vector2(0.5f, 0.5f);
    }
}








