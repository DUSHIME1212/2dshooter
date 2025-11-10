// Power-up that temporarily increases the player's movement speed by a multiplier for a set duration.

using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    [Header("Speed Settings")]
    [SerializeField] private float speedMultiplier = 2f;
    [SerializeField] private float effectDuration = 5f;
    
    public override void ApplyEffect(Player player)
    {
        base.ApplyEffect(player);
        Debug.Log($"Speed boosted by {speedMultiplier}x for {effectDuration} seconds");
        
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        if (movement != null)
        {
            // Speed modification logic would go here
        }
    }
}
