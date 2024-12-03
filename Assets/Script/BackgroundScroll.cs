using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    public Image background;  // background 오브젝트의 Image 컴포넌트를 연결
    private float backgroundSpeed = 0.05f;  // 스크롤 속도

    private Vector2 backgroundScrollOffset = Vector2.zero;

    void Start()
    {
        // background 오브젝트가 연결되지 않았을 경우, 자식 오브젝트에서 가져옵니다.
        if (background == null && transform.childCount > 0)
        {
            background = transform.GetChild(0).GetComponent<Image>();

            if (background == null)
            {
                Debug.LogError("자식 오브젝트에 Image 컴포넌트가 없습니다.");
                return;
            }

            // Material을 인스턴스화하여 다른 오브젝트와 공유하지 않도록 합니다.
            background.material = new Material(background.material);
        }
        else if (background == null)
        {
            Debug.LogError("background 오브젝트에 자식이 없습니다.");
            return;
        }

        Debug.Log("background 오브젝트의 자식 개수: " + transform.childCount);
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
        // Offset 값을 반복하여 일정한 범위 내에서 스크롤 효과를 만듭니다.
        backgroundScrollOffset.x = Mathf.Repeat(backgroundScrollOffset.x + (backgroundSpeed * Time.deltaTime), 1);
        background.material.mainTextureOffset = backgroundScrollOffset;
    }
}

/*private void ScrollBackgroundImage()
    {
        backgroundScrollOffset.x += (backgroundSpeed * Time.deltaTime);

        // 인스턴스화된 머티리얼의 mainTextureOffset을 조정합니다.
        background.material.mainTextureOffset = backgroundScrollOffset;
    }*/
