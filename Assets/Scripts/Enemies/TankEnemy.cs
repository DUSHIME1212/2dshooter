using UnityEngine;

public class TankEnemy : Enemy
{
    [Header("Tank Enemy Settings")]
    [SerializeField] private float chargeSpeed = 6f;
    [SerializeField] private float chargeDistance = 3f;
    
    private bool isCharging = false;
    private Vector3 chargeDirection;
    private float normalSpeed;
    
    protected override void Start()
    {
        base.Start();
        health = 100;
        speed = 1f;
        scoreValue = 300;
        canShoot = true;
        
        normalSpeed = speed;
    }
    
    protected override void Move()
    {
        if (isCharging)
        {
            transform.Translate(chargeDirection * chargeSpeed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, player.position) > chargeDistance * 2f)
            {
                isCharging = false;
                speed = normalSpeed;
            }
        }
        else if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, player.position) < chargeDistance)
            {
                StartCharge();
            }
        }
        
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
    
    private void StartCharge()
    {
        isCharging = true;
        if (player != null)
        {
            chargeDirection = (player.position - transform.position).normalized;
        }
    }
    
    protected override void Shoot()
    {
        if (isCharging) return;
        
        base.Shoot();
    }
}