// Power-up that provides a shield effect, healing the player by a set amount when collected.

using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    [Header("Shield Settings")]
    [SerializeField] private int shieldHealth = 50;
    
    public override void ApplyEffect(Player player)
    {
        base.ApplyEffect(player);
        Debug.Log($"Shield activated with {shieldHealth} health");
        player.Heal(25);
    }
}