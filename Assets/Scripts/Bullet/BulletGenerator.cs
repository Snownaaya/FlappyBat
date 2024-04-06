using UnityEngine;
using System;

public abstract class BulletGenerator : MonoBehaviour
{
    [SerializeField] private ObjectPool<Bullet> _bulletPool;
    [SerializeField] private float _speed;
    [SerializeField, Range(-1, 1)] private int _direction;
    [SerializeField] private float _fireRate;

    private float _nextAttackTime = 0f;

    public event Action EnemyAttack;

    public void Shooter()
    {
        if (Time.time >= _nextAttackTime)
        {
            _nextAttackTime = Time.time + _fireRate;

            Shoot();
        }
    }

    protected void Shoot()
    {

        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Bullet bullet = _bulletPool.GetObject();
        bullet.gameObject.SetActive(true);

        bullet.transform.position = position;

        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = transform.right * _speed * _direction;
    }
}
