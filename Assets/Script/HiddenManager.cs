using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenManager : MonoBehaviour
{
    public GameObject HiddenCanvas; //������ ĵ����
    private bool isPaused = false;


    


    public void TogglePause()
    {
        isPaused = !isPaused; // ���� ����

        if (isPaused)
        {

            HiddenCanvas.SetActive(true); // �ɼ� â Ȱ��ȭ
        }
        else
        {

            HiddenCanvas.SetActive(false); // �ɼ� â ��Ȱ��ȭ
        }
    }


}
