using UnityEngine;

public class BulletGenerator : ObjectPool<Bullet>
{
    [SerializeField] private float _speed;
    [SerializeField] private float _fireRate;
    [SerializeField] private Rigidbody2D _rigidbody;

    private float _nextAttackTime = 0f;

    private void Update()
    {
        if (PlayerInput.GetShot())
            Fire();
    }

    public void Fire()
    {
        if (Time.time >= _nextAttackTime)
        {
            _nextAttackTime = Time.time + _fireRate;
            Shoot();
        }
    }

    protected void Shoot()
    {
        Bullet bullet = GetObject();
        bullet.transform.position = transform.position;
        bullet.gameObject.SetActive(true);
        bullet.SetVelocity(_rigidbody.velocity);
    }
}
