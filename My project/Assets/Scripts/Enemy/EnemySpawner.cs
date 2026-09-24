using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyFactory enemyFactory;
    [SerializeField] float spawnInterval;

    private float spawnTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        EnemyType type = (EnemyType)Random.Range(0, 3);

        Vector3 spawnPosition;

        if (Random.value > 0.5f)
        {
            float x = Random.Range(-23f, 23f);
            float z = Random.value > 0.5f ? 23f : -23f;

            spawnPosition = new Vector3(x, 1f, z);
        }
        else
        {
            float x = Random.value > 0.5f ? 23f : -23f;
            float z = Random.Range(-23f, 23f);

            spawnPosition = new Vector3(x, 1f, z);
        }

        enemyFactory.CreateEnemy(type, spawnPosition);
    }
}
