using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_spawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // ������ ��ֹ��� ������
    public float spawnInterval = 2.0f; // ��ֹ� ���� ����
    public float spawnRangeX = 8.0f; // X�࿡�� ��ֹ��� ������ ����
    public float spawnHeight = 10.0f; // ��ֹ��� �����Ǵ� Y�� ����
    public Transform parentTransform; // ��ֹ��� ������ �θ� ������Ʈ
    public int objectsPerSpawn = 3; // �� ���� ������ ��ֹ� ��

    void Start()
    {
        // �ݺ������� ��ֹ��� �����ϴ� �ڷ�ƾ ����
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            for (int i = 0; i < objectsPerSpawn; i++)
            {
                // X�࿡�� ���� ��ġ ���
                float randomX = Random.Range(-spawnRangeX, spawnRangeX);

                // ��ֹ� ���� ��ġ ����
                Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0);

                // ��ֹ� ����
                GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, parentTransform);

                // ��ֹ��� Rigidbody2D�� �ִٸ� �߷� ����
                Rigidbody2D rb = newObstacle.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.gravityScale = 1.0f; // �߷� Ȱ��ȭ
                }
            }

            // ���� ��ֹ��� �����ϱ� �� ���
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // DeathZone �Ǵ� Tilemap�� ��Ҵ��� Ȯ��
        if (collision.CompareTag("DeathZone") || collision.CompareTag("Tilemap"))
        {
            Destroy(gameObject); // Falling Object�� ����
        }
    }
}
