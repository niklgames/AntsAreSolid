using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rigidBody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
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
    }

    private void OnMove(InputValue value)
    {
        _movementInput = value.Get<Vector2>();
    }
}
