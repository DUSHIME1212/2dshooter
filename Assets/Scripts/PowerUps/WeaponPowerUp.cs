// Power-up that upgrades the player's weapon by increasing damage and fire rate.

using UnityEngine;

public class WeaponPowerUp : PowerUp
{
    [Header("Weapon Settings")]
    [SerializeField] private int damageBoost = 10;
    [SerializeField] private float fireRateBoost = 0.1f;
    
    public override void ApplyEffect(Player player)
    {
        base.ApplyEffect(player);
        Debug.Log($"Weapon upgraded! Damage: +{damageBoost}, Fire Rate: +{fireRateBoost}");
        
        LaserWeapon weapon = player.GetComponentInChildren<LaserWeapon>();
        if (weapon != null)
        {
            weapon.UpgradeWeapon(damageBoost, fireRateBoost);
        }
    }
}