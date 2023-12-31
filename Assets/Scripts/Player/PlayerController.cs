using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    public float _moveSpeed;

    private Rigidbody2D _rigidBody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private Camera _camera;
    private Animator animator;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        PlayerSmoothedMovement();
        RotateInDirectionOfInput();
    }

    private void PlayerSmoothedMovement()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput,
                                                         _movementInput,
                                                         ref _movementInputSmoothVelocity,
                                                         0.1f);

        _rigidBody.velocity = _smoothedMovementInput * _moveSpeed * Time.fixedDeltaTime;

        
        
    }

    private void RotateInDirectionOfInput()
    {
        if (_movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidBody.MoveRotation(rotation);
        }

        PreventPlayerGoingOffScreen();
    }

    private void PreventPlayerGoingOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < 0 && _rigidBody.velocity.x < 0) ||
            (screenPosition.x > _camera.pixelWidth && _rigidBody.velocity.x > 0))
        {
            _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
        }

        if ((screenPosition.y < 0 && _rigidBody.velocity.y < 0) ||
            (screenPosition.y > _camera.pixelHeight && _rigidBody.velocity.y > 0))
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
        }
    }

    private void OnMove(InputValue value)
    {
        _movementInput = value.Get<Vector2>();
    }
}
