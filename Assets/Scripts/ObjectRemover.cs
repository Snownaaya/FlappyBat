using UnityEngine;
using System;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private EnemyGenerator _enemy;
    [SerializeField] private BulletGenerator _bulletPool;
    [SerializeField] private EnemyBulletSpawner _bulletSpawner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            _enemy.ReturnObject(enemy);

        if (other.TryGetComponent(out Bullet bullet))
            _bulletPool.ReturnObject(bullet);

        if (other.TryGetComponent(out Bullet bullets))
            _bulletSpawner.ReturnObject(bullets);
    }
}
