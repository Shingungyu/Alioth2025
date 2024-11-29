using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
    public class Switch : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField]
        bool isOn = false;

        [SerializeField]
        Animator animator;

        [SerializeField]
        AudioSource backgroundAudio;

        [System.Serializable]
        public class SwitchEvent : UnityEvent<bool> { }

        [SerializeField]
        SwitchEvent onValueChanged = new SwitchEvent();

        public bool IsOn
        {
            get => isOn;
            set
            {
                if (isOn == value) return;
                isOn = value;
                UpdateGUI(false);
            }
        }

        void Start()
        {
            UpdateGUI(true);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isOn = !isOn; // ����ġ ���� ���
            UpdateGUI(false); // UI ������Ʈ
            ToggleBackgroundAudio(isOn); // ��� ���� ���
        }

        void UpdateGUI(bool isInit)
        {
            if (isInit)
            {
                animator.Play(isOn ? "On Init" : "Off Init", 0, 0);
            }
            else
            {
                animator.Play(isOn ? "On" : "Off", 0, 0);
                onValueChanged.Invoke(isOn);
            }
        }

        public void ToggleBackgroundAudio(bool isOn)
        {
            if (backgroundAudio != null)
            {
                backgroundAudio.mute = !isOn;
            }
        }
    }
}
