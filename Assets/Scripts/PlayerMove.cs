using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const float MoveSpeed = 4.5f;
    private const float Gravity = -9.8f;
    
    private CharacterController _controller;
    private Vector3 _moveDirection = Vector3.zero;
    private float _yVelocity;
    
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleInput();
        Move();
    }

    private void HandleInput()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector3(horizontal, 0, vertical).normalized;
    }

    private void Move()
    {
        if (_controller.collisionFlags == CollisionFlags.Below)
        {
            _yVelocity = 0;
        }
        
        _yVelocity += Gravity * Time.deltaTime;
        _moveDirection.y = _yVelocity;
        
        _controller.Move(_moveDirection * (MoveSpeed * Time.deltaTime));
    }
}