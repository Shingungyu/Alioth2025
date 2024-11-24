using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject optionsCanvas; // �ɼ� UI ĵ����
    private bool isPaused = false;


   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }


    }
    public void TogglePause()
    {
        isPaused = !isPaused; // ���� ����

        if (isPaused)
        {
            Time.timeScale = 0f; // ���� �Ͻ�����
            optionsCanvas.SetActive(true); // �ɼ� â Ȱ��ȭ
        }
        else
        {
            Time.timeScale = 1f; // ���� �簳
            optionsCanvas.SetActive(false); // �ɼ� â ��Ȱ��ȭ
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Lobby"); // ���� ȭ�� �� �̸����� �ε�
    }
}

