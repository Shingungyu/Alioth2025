using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttonText;                   // 버튼의 텍스트
    public Color hoverColor = Color.red;      // 마우스 오버 시 텍스트 색상
    public Color normalColor = Color.white;   // 기본 텍스트 색상

    public string soundFilePath = "GameSounds/Hover_sound"; // Resources/GameSounds 안에 있는 파일 경로

    private AudioClip hoverSound;             // 동적으로 로드한 사운드 파일
    private AudioSource audioSource;          // 사운드를 재생할 AudioSource

    void Start()
    {
        if (buttonText == null)
        {
            Debug.LogError("ButtonText is not assigned!");
        }

        // Resources 폴더에서 사운드 파일 로드
        hoverSound = Resources.Load<AudioClip>(soundFilePath);
        if (hoverSound == null)
        {
            Debug.LogError($"Sound file '{soundFilePath}' not found in Resources folder!");
        }

        // AudioSource 컴포넌트 동적으로 추가
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // 자동 재생 비활성화
        audioSource.volume = 1f;         // 볼륨 설정
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = hoverColor; // 텍스트 색상 변경
        }

        // 사운드 재생
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = normalColor; // 텍스트 색상 복원
        }
    }
}