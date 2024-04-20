using UnityEngine;
 
public class EnemyBulletSpawner : ObjectPool<Bullet>
{
    [SerializeField] Rigidbody2D _rigidbody;

    public void SpawnBullet(Vector3 position)
    {
        Bullet bullet = GetObject();
        bullet.transform.position = position;
        bullet.SetVelocity(_rigidbody.velocity);
        bullet.gameObject.SetActive(true);
    }
}
