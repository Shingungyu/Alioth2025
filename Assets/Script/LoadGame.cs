using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void NewGame()// �����ϱ� ��ư ���� �Լ�
    {
        SceneManager.LoadScene("Main1"); // Main1 �� ����
    }
    public void ContinueGame() // �̾��ϱ� ��ư ���� �Լ�
    {
        SceneManager.LoadScene("Continue"); // Continue �� ���� 
    }
    public void Option()//���� ��ư ���� �Լ�
    {
        SceneManager.LoadScene("Option"); // Option �� ���� 
    }
    public void Exit()//���� ��ư ���� �Լ�
    {
        SceneManager.LoadScene("Lobby"); // Lobby �� ���� 
    }
}
