using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{

    public string stage1_1;

    public void NewGame()// �����ϱ� ��ư ���� �Լ�
    {
        SceneManager.LoadScene(stage1_1); // Stage1-1 �� ����
    }
    public void ContinueGame() // �̾��ϱ� ��ư ���� �Լ�
    {
        SceneManager.LoadScene("Continue"); // Continue �� ���� 
    }
    public void Option()//���� ��ư ���� �Լ�
    {
        SceneManager.LoadScene("Option"); // Option �� ���� 
    }
}
