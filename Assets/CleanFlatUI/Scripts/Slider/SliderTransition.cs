using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

namespace RainbowArt.CleanFlatUI
{
    [ExecuteAlways]
    public class SliderTransition: MonoBehaviour,IPointerDownHandler
    {
        [SerializeField]
        Slider slider;

        [SerializeField]
        Animator animator;

        [SerializeField]
        bool hasText = true;

        [SerializeField]
        TextMeshProUGUI text;

        [SerializeField]
        private string targetObjectName; // 오디오 소스가 있는 오브젝트의 이름

        AudioSource audioSource;

        bool bDelayedUpdate = false;

        public bool HasText
        {
            get => hasText;
            set
            {
                hasText = value;
                UpdateText();
            }
        }

        void UpdateText()
        {
            if (text != null && text.gameObject.activeSelf != hasText)
            {
                text.gameObject.SetActive(hasText);
            }
            if (hasText && (text != null))
            {
                float useValue = (float)Math.Round((double)slider.value, 1);
                text.text = useValue + "";
            }
        }

        void Start ()
        {
            if(slider == null)
            {
                slider = GetComponent<Slider>();
            }            
            slider.onValueChanged.AddListener(SliderValueChange);

            if (audioSource == null && !string.IsNullOrEmpty(targetObjectName))
            {
                GameObject targetObject = GameObject.Find(targetObjectName);
                if (targetObject != null)
                {
                    audioSource = targetObject.GetComponent<AudioSource>();
                }
            }

            SliderValueChange(slider.value);
        }

        void Update()
        {
            if(bDelayedUpdate)
            {
                bDelayedUpdate = false;
                if(text != null)
                {
                    text.gameObject.SetActive(hasText);
                }
                if(slider == null)
                {
                    slider = GetComponent<Slider>();
                }  
                SliderValueChange(slider.value);   
            }
        }

        public void SliderValueChange(float value)
        {
            if (hasText && (text != null))
            {
                float useValue = (float)Math.Round((double)slider.value, 1);
                text.text = useValue +"";
            }

            if (audioSource != null)
            {
                audioSource.volume = value; // 슬라이더 값으로 오디오 볼륨 설정
            }
        } 

        public void OnPointerDown(PointerEventData eventData)
        {
            if(animator!=null)
            {
                animator.Play("Transition",0,0);  
            }                      
        }

        #if UNITY_EDITOR
        protected void OnValidate()
        {
            bDelayedUpdate = true;           
        }
        #endif
    }
}