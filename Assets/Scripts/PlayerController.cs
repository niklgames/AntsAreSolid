using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;
    
    private Rigidbody2D _rigidBody;
    private Vector2 _movementInput;
    private Vector2 _smoothedInputInput;
    private Vector2 _movementInputSmoothVelocity;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _smoothedInputInput = Vector2.SmoothDamp(_smoothedInputInput,
                                                 _movementInput,
                                                 ref _movementInputSmoothVelocity,
                                                 0.1f);

        _rigidBody.velocity = _smoothedInputInput * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnMove(InputValue value)
    {
        _movementInput = value.Get<Vector2>();
    }
}
