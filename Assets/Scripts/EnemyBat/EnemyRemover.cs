using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    [SerializeField] private ExampleEnemyPool _enemy;
    [SerializeField] private ExampleBulletPool _bulletPool;

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
