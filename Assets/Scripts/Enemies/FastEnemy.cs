using UnityEngine;

public class FastEnemy : Enemy
{
    [Header("Fast Enemy Settings")]
    [SerializeField] private float changeDirectionInterval = 1f;
    
    private Vector3 movementDirection;
    private float nextDirectionChange;
    
    protected override void Start()
    {
        base.Start();
        speed = 4f;
        health = 15;
        scoreValue = 150;
        
        movementDirection = Random.insideUnitSphere.normalized;
        movementDirection.z = 0;
        nextDirectionChange = Time.time + changeDirectionInterval;
    }
    
    protected override void Move()
    {
        if (Time.time >= nextDirectionChange)
        {
            movementDirection = Random.insideUnitSphere.normalized;
            movementDirection.z = 0;
            nextDirectionChange = Time.time + changeDirectionInterval;
        }
        
        transform.Translate(movementDirection * speed * Time.deltaTime);
        
        Vector3 position = transform.position;
        if (Mathf.Abs(position.x) > 9f || position.y < -7f || position.y > 7f)
        {
            Destroy(gameObject);
        }
    }
}