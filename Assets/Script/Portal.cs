using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneName;
    private bool PlayerCol = false;

    GameObject Player;

    void Awake()
    {
        if (Player == null)
            Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (PlayerCol && Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        //Player�±׸� ���� ������Ʈ�� �浹���� ��
        if (collider2D.gameObject == Player)
        {
            PlayerCol = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        //Player�±׸� ���� ������Ʈ�� �浹���� ����� ��
        if (collider2D.gameObject == Player)
        {
            PlayerCol = false;
        }
    }
}
