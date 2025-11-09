using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float boundaryX = 8f;
    [SerializeField] private float boundaryYMin = -4.5f;
    [SerializeField] private float boundaryYMax = 4.5f;
    
    private void Update()
    {
        HandleMovement();
    }
    
    private void HandleMovement()
    {
#if ENABLE_INPUT_SYSTEM
        // New Input System
        float moveX = 0f;
        float moveY = 0f;
        
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveX = -1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) moveX = 1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moveY = -1f;
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) moveY = 1f;
        }
#else
        // Old Input System
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
#endif
        
        Vector3 movement = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
        
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -boundaryX, boundaryX);
        position.y = Mathf.Clamp(position.y, boundaryYMin, boundaryYMax);
        transform.position = position;
    }
}
