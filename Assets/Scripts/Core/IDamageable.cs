// Defines the interface for objects that can take damage and die, allowing for consistent damage handling across different game entities.

using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int damage);
    void Die();
}