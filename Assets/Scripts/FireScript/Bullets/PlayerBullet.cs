using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBullet : Bullet
{
    [SerializeField] private Enemy _enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemy.OnEnemyDestroyed();
            enemy.gameObject.SetActive(false);
        }
    }
}