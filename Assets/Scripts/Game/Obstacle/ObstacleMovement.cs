using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObstacleMovement : MonoBehaviour
{
    [Range(5, 20)]
    [SerializeField] private int _speed = 5;

    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveLeft();
    }

    private void MoveLeft()
    {
        var absSpeed = Mathf.Abs(_speed);
        _rigidBody.velocity += new Vector2(-absSpeed * Time.deltaTime, 0f);
    }
}
