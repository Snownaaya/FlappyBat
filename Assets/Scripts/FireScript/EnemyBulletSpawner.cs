using UnityEngine;
using System.Collections;
 
public class EnemyBulletSpawner : ObjectPool<Bullet>
{
    [SerializeField] Rigidbody2D _rigidbody;

    public void Shoot()
    {
        Bullet bullet = GetObject();
        bullet.transform.position = transform.position;
        bullet.SetVelocity(_rigidbody.velocity);
        bullet.gameObject.SetActive(true);
    }
}
