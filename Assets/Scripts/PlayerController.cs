using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;
    
    private Rigidbody2D _rigidBody;
    private Vector2 _movementInput;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = _movementInput * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnMove(InputValue value)
    {
        _movementInput = value.Get<Vector2>();
    }
}
