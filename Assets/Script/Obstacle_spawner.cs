using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_spawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // 떨어질 장애물의 프리팹
    public float spawnInterval = 2.0f; // 장애물 생성 간격
    public float spawnRangeX = 8.0f; // X축에서 장애물이 생성될 범위
    public float spawnHeight = 10.0f; // 장애물이 생성되는 Y축 높이
    public Transform parentTransform; // 장애물이 생성될 부모 오브젝트
    public int objectsPerSpawn = 3; // 한 번에 생성할 장애물 수

    void Start()
    {
        // 반복적으로 장애물을 생성하는 코루틴 시작
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            for (int i = 0; i < objectsPerSpawn; i++)
            {
                // X축에서 랜덤 위치 계산
                float randomX = Random.Range(-spawnRangeX, spawnRangeX);

                // 장애물 생성 위치 설정
                Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0);

                // 장애물 생성
                GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, parentTransform);

                // 장애물에 Rigidbody2D가 있다면 중력 적용
                Rigidbody2D rb = newObstacle.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.gravityScale = 1.0f; // 중력 활성화
                }
            }

            // 다음 장애물을 생성하기 전 대기
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // DeathZone 또는 Tilemap에 닿았는지 확인
        if (collision.CompareTag("DeathZone") || collision.CompareTag("Tilemap"))
        {
            Destroy(gameObject); // Falling Object를 삭제
        }
    }
}
