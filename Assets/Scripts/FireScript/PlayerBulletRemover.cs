using UnityEngine;

public class PlayerBulletRemover : MonoBehaviour
{
    [SerializeField] private BulletGenerator _bulletPool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            _bulletPool.ReturnObject(bullet);
        }
    }
}
