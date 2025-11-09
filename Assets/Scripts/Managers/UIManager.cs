using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Score UI")]
    [SerializeField] private TextMeshProUGUI scoreText;
    
    [Header("Health UI")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;
    
    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    
    [Header("Power-up UI")]
    [SerializeField] private Image shieldIcon;
    [SerializeField] private Image speedIcon;
    [SerializeField] private Image weaponIcon;
    
    private void Start()
    {
        GameEvents.Instance.OnScoreChanged += UpdateScore;
        GameEvents.Instance.OnPlayerHealthChanged += UpdateHealth;
        GameEvents.Instance.OnPlayerDeath += ShowGameOver;
        GameEvents.Instance.OnPowerUpCollected += UpdatePowerUpUI;
        
        gameOverPanel.SetActive(false);
        UpdateScore(0);
        UpdateHealth(100);
        
        SetPowerUpIconAlpha(shieldIcon, 0.3f);
        SetPowerUpIconAlpha(speedIcon, 0.3f);
        SetPowerUpIconAlpha(weaponIcon, 0.3f);
    }
    
    private void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = $"SCORE: {score}";
    }
    
    private void UpdateHealth(int health)
    {
        if (healthSlider != null)
            healthSlider.value = health;
        
        if (healthText != null)
            healthText.text = $"{health}";
        
        if (healthSlider != null && healthSlider.fillRect != null)
        {
            Image fillImage = healthSlider.fillRect.GetComponent<Image>();
            if (fillImage != null)
            {
                fillImage.color = health > 70 ? Color.green : 
                                health > 30 ? Color.yellow : Color.red;
            }
        }
    }
    
    private void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            if (finalScoreText != null)
                finalScoreText.text = $"FINAL SCORE: {GameManager.Instance.CurrentScore}";
        }
    }
    
    private void UpdatePowerUpUI(PowerUpType type)
    {
        Image targetIcon = type switch
        {
            PowerUpType.Shield => shieldIcon,
            PowerUpType.Speed => speedIcon,
            PowerUpType.Weapon => weaponIcon,
            _ => null
        };
        
        if (targetIcon != null)
        {
            StartCoroutine(FlashIcon(targetIcon));
        }
    }
    
    private System.Collections.IEnumerator FlashIcon(Image icon)
    {
        SetPowerUpIconAlpha(icon, 1f);
        yield return new WaitForSeconds(2f);
        SetPowerUpIconAlpha(icon, 0.3f);
    }
    
    private void SetPowerUpIconAlpha(Image icon, float alpha)
    {
        if (icon != null)
        {
            Color color = icon.color;
            color.a = alpha;
            icon.color = color;
        }
    }
    
    public void OnRestartButtonClicked()
    {
        GameManager.Instance.RestartGame();
    }
    
    private void OnDestroy()
    {
        if (GameEvents.Instance != null)
        {
            GameEvents.Instance.OnScoreChanged -= UpdateScore;
            GameEvents.Instance.OnPlayerHealthChanged -= UpdateHealth;
            GameEvents.Instance.OnPlayerDeath -= ShowGameOver;
            GameEvents.Instance.OnPowerUpCollected -= UpdatePowerUpUI;
        }
    }
}
