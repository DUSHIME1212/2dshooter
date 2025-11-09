using UnityEngine;

public class LaserWeapon : Weapon
{
    [Header("Laser Specific")]
    [SerializeField] private bool isPlayerWeapon = true;
    
    public override void Fire()
    {
        if (CanFire() && projectilePrefab != null && firePoint != null)
        {
            GameObject projectileObject = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Projectile projectile = projectileObject.GetComponent<Projectile>();
            
            if (projectile != null)
            {
                projectile.SetDamage(damage);
                projectile.SetIsPlayerProjectile(isPlayerWeapon);
            }
            
            nextFireTime = Time.time + fireRate;
            Debug.Log("Laser fired!");
        }
    }
    
    public override void Reload()
    {
        Debug.Log("Laser weapon reloaded (conceptual)");
    }
    
    public void UpgradeWeapon(int newDamage, float newFireRate)
    {
        damage = newDamage;
        fireRate = newFireRate;
        Debug.Log($"Weapon upgraded! Damage: {damage}, Fire Rate: {fireRate}");
    }
}
