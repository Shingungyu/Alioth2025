using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    string sceneName = GameManager.sceneName;

    public void Exit()
    {
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
