// Factory class responsible for instantiating different types of enemies based on the EnemyType enum, ensuring proper setup and error handling.

using UnityEngine;

public enum EnemyType
{
    Basic,
    Fast,
    Tank
}

public class EnemyFactory : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject basicEnemyPrefab;
    [SerializeField] private GameObject fastEnemyPrefab;
    [SerializeField] private GameObject tankEnemyPrefab;
    
    public Enemy CreateEnemy(EnemyType type, Vector3 position)
    {
        GameObject enemyPrefab = type switch
        {
            EnemyType.Basic => basicEnemyPrefab,
            EnemyType.Fast => fastEnemyPrefab,
            EnemyType.Tank => tankEnemyPrefab,
            _ => basicEnemyPrefab
        };
        
        if (enemyPrefab == null)
        {
            Debug.LogError($"Enemy prefab for type {type} is not assigned!");
            return null;
        }
        
        GameObject enemyObject = Instantiate(enemyPrefab, position, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        
        if (enemy == null)
        {
            Debug.LogError($"Enemy component not found on prefab for type {type}");
            return null;
        }
        
        Debug.Log($"Created {type} enemy at {position}");
        return enemy;
    }
}