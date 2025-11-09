using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Playing,
    Paused,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public int CurrentScore { get; private set; }
    public GameState CurrentState { get; private set; }
    
    public event System.Action<int> OnScoreChanged;
    public event System.Action<GameState> OnGameStateChanged;
    
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
        
        CurrentState = GameState.Playing;
    }
    
    public void AddScore(int points)
    {
        CurrentScore += points;
        OnScoreChanged?.Invoke(CurrentScore);
        Debug.Log($"Score updated: {CurrentScore}");
    }
    
    public void SetGameState(GameState newState)
    {
        CurrentState = newState;
        OnGameStateChanged?.Invoke(newState);
        
        Time.timeScale = newState == GameState.Paused ? 0 : 1;
    }
    
    public void RestartGame()
    {
        CurrentScore = 0;
        CurrentState = GameState.Playing;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void GameOver()
    {
        SetGameState(GameState.GameOver);
        Debug.Log("Game Over!");
    }
}