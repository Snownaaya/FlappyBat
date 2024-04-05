using UnityEngine;
using System;

public class PlayerBullet : BulletGenerator
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Start()
    {
        StartCoroutine(Shoot());

        _rigidbody.velocity = transform.right * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ExampleEnemyPool enemy))
        {
            Destroy(gameObject);
        }
    }
}