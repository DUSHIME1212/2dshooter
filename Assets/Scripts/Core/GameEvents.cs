// Handles global game events and notifications, such as score changes, player health updates, and power-up collections.
// Acts as a central event dispatcher using the Singleton pattern to ensure consistent event management across the game.

using UnityEngine;

public enum PowerUpType
{
    Shield,
    Speed,
    Weapon
}

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;
    
    public event System.Action<int> OnPlayerHealthChanged;
    public event System.Action<int> OnScoreChanged;
    public event System.Action OnPlayerDeath;
    public event System.Action<PowerUpType> OnPowerUpCollected;
    public event System.Action OnEnemyDestroyed;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayerHealthChanged(int health)
    {
        OnPlayerHealthChanged?.Invoke(health);
    }
    
    public void ScoreChanged(int score)
    {
        OnScoreChanged?.Invoke(score);
    }
    
    public void PlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }
    
    public void PowerUpCollected(PowerUpType type)
    {
        OnPowerUpCollected?.Invoke(type);
    }
    
    public void EnemyDestroyed()
    {
        OnEnemyDestroyed?.Invoke();
    }
}