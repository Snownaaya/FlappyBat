using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField, Range(-1, 1)] private int _direction;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

    public void SetVelocity(Vector2 vector) => _rigidbody.velocity = new Vector2(_direction * _speed, 0f) + vector;
}
