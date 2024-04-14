using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    [SerializeField] private EnemyGenerator _enemy;
    [SerializeField] private EnemyBulletSpawner _bulletPool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemy.ReturnObject(enemy);
        }

        if (other.TryGetComponent(out Bullet bullet))
        {
            _bulletPool.ReturnObject(bullet);
        }
    }
}
