using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _jumpVelocity = new Vector2(1f, 0.1f);
    private Rigidbody2D _rigidBody;

    private bool _canJump;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _canJump = Mathf.Abs(_rigidBody.velocity.y) < float.Epsilon;
    }

    public void Jump()
    {
        if (!_canJump)
        {
            return;
        }

        var forwardVelocity = transform.position.x <= 0 ? _jumpVelocity.x : 0f;

        _rigidBody.velocity = new Vector2(forwardVelocity, _jumpVelocity.y);
    }
}
