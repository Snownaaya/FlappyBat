using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy) && other.GetType() == typeof(PolygonCollider2D))
            enemy.gameObject.SetActive(false);
    }
}