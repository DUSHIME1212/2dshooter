// Base abstract class for all power-ups, handling falling movement, collision with player, and applying effects.
// Subclasses implement specific power-up behaviors like shield, speed, or weapon upgrades.

using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [Header("PowerUp Settings")]
    [SerializeField] protected PowerUpType powerUpType;
    [SerializeField] protected float duration = 5f;
    [SerializeField] protected float fallSpeed = 2f;
    
    public PowerUpType Type => powerUpType;
    
    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
    
    public virtual void ApplyEffect(Player player)
    {
        Debug.Log($"Applying {powerUpType} power-up effect");
        GameEvents.Instance.PowerUpCollected(powerUpType);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                ApplyEffect(player);
            }
        }
    }
}