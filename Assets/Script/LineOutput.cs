using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LineOutput : MonoBehaviour
{
    public Text text1;

    private void Start()
    {
        if (text1 != null)
        {
            text1.DOText("�����ٶ󸶹ٻ�", 3f);
        }
        else
        {
            Debug.LogError("Text component is not assigned!");
        }
    }
}
