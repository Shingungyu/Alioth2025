using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void NewGame()//�����ϱ� ��ư ���� �Լ�
    {
        //NEW ���� Main�� ���Ƿ� �����Ͽ����ϴ�.
        SceneManager.LoadScene("Main");//Main1 �� ����
    }
    public void ContinueGame()//�̾��ϱ� ��ư ���� �Լ�
    {
        SceneManager.LoadScene("Continue"); ;//Continue �� ���� 
    }
    public void Option()//���� ��ư ���� �Լ�
    {
        SceneManager.LoadScene("Option"); ;//Option �� ���� 
    }
    public void Exit()//���� ��ư ���� �Լ�
    {
        SceneManager.LoadScene("SampleScene"); ;//SampleScene �� ���� 
    }
}
