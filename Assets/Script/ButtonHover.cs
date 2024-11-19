using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttonText;                   // ��ư�� �ؽ�Ʈ
    public Color hoverColor = Color.red;      // ���콺 ���� �� �ؽ�Ʈ ����
    public Color normalColor = Color.white;   // �⺻ �ؽ�Ʈ ����

    public string soundFilePath = "GameSounds/Hover_sound"; // Resources/GameSounds �ȿ� �ִ� ���� ���

    private AudioClip hoverSound;             // �������� �ε��� ���� ����
    private AudioSource audioSource;          // ���带 ����� AudioSource

    void Start()
    {
        if (buttonText == null)
        {
            Debug.LogError("ButtonText is not assigned!");
        }

        // Resources �������� ���� ���� �ε�
        hoverSound = Resources.Load<AudioClip>(soundFilePath);
        if (hoverSound == null)
        {
            Debug.LogError($"Sound file '{soundFilePath}' not found in Resources folder!");
        }

        // AudioSource ������Ʈ �������� �߰�
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // �ڵ� ��� ��Ȱ��ȭ
        audioSource.volume = 1f;         // ���� ����
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = hoverColor; // �ؽ�Ʈ ���� ����
        }

        // ���� ���
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = normalColor; // �ؽ�Ʈ ���� ����
        }
    }
}