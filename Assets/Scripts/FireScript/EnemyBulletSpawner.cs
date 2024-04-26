using UnityEngine;

public class EnemyBulletSpawner : ObjectPool<Bullet>
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private bool _isPlayerBullet;

    public void SpawnBullet(Transform shotPosition)
    {
        Bullet bullet = GetObject();
        bullet.transform.position = shotPosition.position;
        bullet.SetVelocity(_rigidbody.velocity);
        bullet.gameObject.SetActive(true);
    }
}
