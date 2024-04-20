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

        else if (other.TryGetComponent(out PlayerBullet bullet))
            _playerBullet.ReturnObject(bullet);

        else if (other.TryGetComponent(out EnemyBullet bullets))
            _enemyBullet.ReturnObject(bullets);
    }
}
