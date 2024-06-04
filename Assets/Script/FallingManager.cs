using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingManager : MonoBehaviour
{
    public static FallingManager instance = null;
    [SerializeField] GameObject platform;
    [SerializeField] float posX1, posX2, posX3, posY;
    [SerializeField] float spawnTime = 2f;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Instantiate(platform, new Vector2(posX1, posY), platform.transform.rotation);
        Instantiate(platform, new Vector2(posX2, posY), platform.transform.rotation);
        Instantiate(platform, new Vector2(posX3, posY), platform.transform.rotation);
    }

    public IEnumerator SpawnPlatform(Vector2 spawnPos) { 
        yield return new WaitForSeconds(spawnTime);
        Instantiate(platform, spawnPos, platform.transform.rotation);
   
    }
}
