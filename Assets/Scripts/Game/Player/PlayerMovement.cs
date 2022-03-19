using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _jumpVelocity = new Vector2(1f, 0.1f);
    private Rigidbody2D _rigidBody;

    private bool CanJump => _rigidBody.velocity.y == 0f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (!CanJump)
        {
            return;
        }

        var forwardVelocity = transform.position.x <= 0 ? _jumpVelocity.x : 0f;

        _rigidBody.velocity = new Vector2(forwardVelocity, _jumpVelocity.y);
    }
}
