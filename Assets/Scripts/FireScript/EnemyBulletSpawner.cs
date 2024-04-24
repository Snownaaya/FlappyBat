using UnityEngine;

public class EnemyBulletSpawner : ObjectPool<Bullet>
{
    [SerializeField] Rigidbody2D _rigidbody;

    public void SpawnBullet(Transform shotPosition)
    {
        Bullet bullet = GetObject();
        bullet.transform.position = shotPosition.position;
        bullet.SetVelocity(_rigidbody.velocity);
        bullet.gameObject.SetActive(true);
    }
}
