using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
    public class Switch : MonoBehaviour,IPointerDownHandler 
    {
        [SerializeField]
        bool isOn = false;   

        [SerializeField]        
        Animator animator;

        [SerializeField]
        AudioSource audioSource;

        [Serializable]
        public class SwitchEvent : UnityEvent<bool>{ }

        [SerializeField]
        SwitchEvent onValueChanged = new SwitchEvent();     
             
        public bool IsOn
        {
            get => isOn;
            set
            {
                if(isOn == value)
                {
                    return;
                }
                isOn = value;
                UpdateGUI(false);
            }
        }    

        public SwitchEvent OnValueChanged
        {
            get => onValueChanged;
            set
            {
                onValueChanged = value;
            }
        }  

        void Start () 
        {
           UpdateGUI(true);
        }   

        public void OnPointerDown(PointerEventData eventData)
        {
            isOn = !isOn;  
            UpdateGUI(false);      
        }  

        void UpdateGUI(bool isInit)
        {
            if(isInit)
            {
                if(isOn)
                {
                    animator.Play("On Init",0,0); 
                }
                else
                {
                    animator.Play("Off Init",0,0); 
                } 
            }
            else
            {
                if(isOn)
                {
                    animator.Play("On",0,0); 
                    onValueChanged.Invoke(true);
                }
                else
                {
                    animator.Play("Off",0,0); 
                    onValueChanged.Invoke(false);
                } 
            }            
        }

        public void PlaySound(AudioClip clip)
        {
            if (audioSource != null && clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}