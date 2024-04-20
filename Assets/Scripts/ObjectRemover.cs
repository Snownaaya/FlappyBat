using UnityEngine;
using System;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private EnemyGenerator _enemy;
    [SerializeField] private BulletGenerator _playerBullet;
    [SerializeField] private EnemyBulletSpawner _enemyBullet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            _enemy.ReturnObject(enemy);

        if (other.TryGetComponent(out Bullet bullet))
            _playerBullet.ReturnObject(bullet);

        if (other.TryGetComponent(out Bullet bullets))
            _enemyBullet.ReturnObject(bullets);
    }
}
