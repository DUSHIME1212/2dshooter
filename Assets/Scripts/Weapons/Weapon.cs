using UnityEngine;

public abstract class Weapon : MonoBehaviour, IShootable
{
    [Header("Weapon Settings")]
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float fireRate = 0.2f;
    [SerializeField] protected int damage = 10;
    
    protected float nextFireTime;
    
    public abstract void Fire();
    public abstract void Reload();
    
    protected virtual bool CanFire()
    {
        return Time.time >= nextFireTime;
    }
}