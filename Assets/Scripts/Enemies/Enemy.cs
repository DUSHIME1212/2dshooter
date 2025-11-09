using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [Header("Enemy Stats")]
    [SerializeField] protected int health = 30;
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected int scoreValue = 100;
    [SerializeField] protected int damage = 10;
    
    [Header("Shooting")]
    [SerializeField] protected bool canShoot = false;
    [SerializeField] protected float shootInterval = 2f;
    [SerializeField] protected GameObject bulletPrefab;
    
    protected Transform player;
    protected float nextShootTime;
    protected int maxHealth;
    
    public int ScoreValue => scoreValue;
    
    protected virtual void Start()
    {
        maxHealth = health;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
            player = playerObject.transform;
        
        nextShootTime = Time.time + Random.Range(1f, shootInterval);
    }
    
    protected virtual void Update()
    {
        Move();
        
        if (canShoot && Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootInterval;
        }
    }
    
    protected abstract void Move();
    
    protected virtual void Shoot()
    {
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
    
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Health: {health}");
        
        if (health <= 0)
        {
            Die();
        }
    }
    
    public virtual void Die()
    {
        GameManager.Instance.AddScore(scoreValue);
        GameEvents.Instance.EnemyDestroyed();
        Debug.Log($"{gameObject.name} destroyed! +{scoreValue} points");
        Destroy(gameObject);
    }
    
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Projectile projectile = other.GetComponent<Projectile>();
            if (projectile != null)
            {
                TakeDamage(projectile.Damage);
                Destroy(other.gameObject);
            }
        }
    }
}
