using UnityEngine;

public class BasicEnemy : Enemy
{
    [Header("Basic Enemy Settings")]
    [SerializeField] private float amplitude = 2f;
    [SerializeField] private float frequency = 1f;
    
    private Vector3 startPosition;
    
    protected override void Start()
    {
        base.Start();
        startPosition = transform.position;
    }
    
    protected override void Move()
    {
        float newX = startPosition.x + Mathf.Sin(Time.time * frequency) * amplitude;
        Vector3 newPosition = new Vector3(newX, transform.position.y - speed * Time.deltaTime, 0);
        transform.position = newPosition;
        
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
}