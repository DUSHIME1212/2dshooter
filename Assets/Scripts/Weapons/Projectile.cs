// Represents a projectile fired by weapons, handling movement, lifetime, and collision with targets.
// Can be configured as player or enemy projectile with different behaviors.

using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 3f;
    [SerializeField] private int damage = 10;
    
    private bool isPlayerProjectile;
    private Vector3 direction;
    
    public int Damage => damage;
    
    private void Start()
    {
        Destroy(gameObject, lifetime);
        direction = transform.up;
    }
    
    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
    
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
    
    public void SetIsPlayerProjectile(bool isPlayer)
    {
        isPlayerProjectile = isPlayer;
        gameObject.tag = isPlayer ? "PlayerBullet" : "EnemyBullet";
    }
    
    private void OnTriggerEnter2D(Collider2D other)
{
    if (isPlayerProjectile && other.CompareTag("Enemy"))
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        damageable?.TakeDamage(damage);
        Destroy(gameObject);
    }
    else if (!isPlayerProjectile && other.CompareTag("Player"))
    {
        Destroy(gameObject);
    }
}
}