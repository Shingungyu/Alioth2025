using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Scene scene;
    public static string sceneName;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sceneName = scene.name;
            SceneManager.LoadScene("Option");
        }
    }
}
