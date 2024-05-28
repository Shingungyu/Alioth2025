using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPortal : MonoBehaviour

{
    public string Main;
    public string Main2;
    GameObject Player;
    private bool PlayerCol = false;//PLayerCol=Player is Colliding(플레이어가 충돌중)
    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
            Player = GameObject.FindWithTag("Player");

    }
    void Update()
    {
        if (PlayerCol && Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Main");
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        //Player태그를 가진 오브젝트와 충돌했을 떄
        if (collider2D.gameObject == Player)
        {
            PlayerCol = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        //Player태그를 가진 오브젝트가 충돌에서 벗어낫을 떄
        if (collider2D.gameObject == Player)
        {
            PlayerCol = false;
        }
    }


}
