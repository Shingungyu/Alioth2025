using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    [SerializeField] float fallTime = 0.5f;
    [SerializeField] float destroyTime = 1.5f;
    Rigidbody2D rb;
    private bool hasCollided = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasCollided && collision.gameObject.name.Equals("Player"))
        {
            hasCollided = true; // 충돌 상태를 업데이트합니다.
            StartCoroutine(FallAndSpawnPlatform());
        }
    }

    private IEnumerator FallAndSpawnPlatform()
    {
        FallingManager.instance.StartCoroutine(FallingManager.instance.SpawnPlatform(new Vector2(transform.position.x, transform.position.y)));
        yield return new WaitForSeconds(fallTime);
        FallPlatform();
        Destroy(gameObject, destroyTime - fallTime); // 이미 기다린 시간만큼 차감하여 파괴
    }

    void FallPlatform()
    {
        rb.isKinematic = false;
    }
}
