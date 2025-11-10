// Handles the spawning of enemy waves at regular intervals, using the EnemyFactory to create random enemy types within defined boundaries.

using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private EnemyFactory enemyFactory;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnBoundary = 8f;
    
    private float nextSpawnTime;
    
    private void Start()
    {
        if (enemyFactory == null)
        {
            enemyFactory = FindFirstObjectByType<EnemyFactory>();
        }
        
        nextSpawnTime = Time.time + spawnInterval;
    }
    
    private void Update()
    {
        if (Time.time >= nextSpawnTime && GameManager.Instance.CurrentState == GameState.Playing)
        {
            SpawnEnemyWave();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
    
    private void SpawnEnemyWave()
    {
        int enemyCount = Random.Range(1, 4);
        
        for (int i = 0; i < enemyCount; i++)
        {
            EnemyType randomType = (EnemyType)Random.Range(0, 3);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnBoundary, spawnBoundary), 6f, 0f);
            
            enemyFactory.CreateEnemy(randomType, spawnPosition);
        }
    }
}