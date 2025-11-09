using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class Player : MonoBehaviour, IDamageable
{
    [Header("Player Stats")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float invulnerabilityTime = 1f;
    
    [Header("References")]
    [SerializeField] private Weapon currentWeapon;
    
    private int currentHealth;
    private float lastDamageTime;
    private bool isInvulnerable;
    
    public event System.Action<int> OnHealthChanged;
    
    private void Start()
    {
        currentHealth = maxHealth;
        
        if (currentWeapon == null)
            currentWeapon = GetComponent<Weapon>();
            
        OnHealthChanged?.Invoke(currentHealth);
        
        Debug.Log("Player initialized with health: " + currentHealth);
    }
    
    private void Update()
    {
        HandleShooting();
        UpdateInvulnerability();
    }
    
    private void HandleShooting()
    {
#if ENABLE_INPUT_SYSTEM
        // New Input System
        if (Keyboard.current != null && Keyboard.current.spaceKey.isPressed && currentWeapon != null)
        {
            currentWeapon.Fire();
        }
#else
        // Old Input System
        if (Input.GetKey(KeyCode.Space) && currentWeapon != null)
        {
            currentWeapon.Fire();
        }
#endif
    }
    
    private void UpdateInvulnerability()
    {
        if (isInvulnerable && Time.time >= lastDamageTime + invulnerabilityTime)
        {
            isInvulnerable = false;
            Debug.Log("Player is no longer invulnerable");
        }
    }
    
    public void TakeDamage(int damage)
    {
        if (isInvulnerable) return;
        
        currentHealth -= damage;
        Debug.Log($"Player took {damage} damage. Health: {currentHealth}");
        
        OnHealthChanged?.Invoke(currentHealth);
        GameEvents.Instance.PlayerHealthChanged(currentHealth);
        
        isInvulnerable = true;
        lastDamageTime = Time.time;
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    public void Die()
    {
        Debug.Log("Player died!");
        GameEvents.Instance.PlayerDeath();
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }
    
    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        OnHealthChanged?.Invoke(currentHealth);
        GameEvents.Instance.PlayerHealthChanged(currentHealth);
        Debug.Log($"Player healed {amount}. Health: {currentHealth}");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Projectile projectile = other.GetComponent<Projectile>();
            if (projectile != null)
            {
                TakeDamage(projectile.Damage);
                Destroy(other.gameObject);
            }
        }
        else if (other.CompareTag("PowerUp"))
        {
            PowerUp powerUp = other.GetComponent<PowerUp>();
            if (powerUp != null)
            {
                powerUp.ApplyEffect(this);
                Destroy(other.gameObject);
            }
        }
        else if (other.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }
}
