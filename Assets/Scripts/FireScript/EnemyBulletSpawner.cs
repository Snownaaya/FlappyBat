using UnityEngine;
using System.Collections;

public class EnemyBulletSpawner : ObjectPool<Bullet>
{
    [SerializeField] Rigidbody2D _rigidbody;

    private float _delay = 1f;

    private Coroutine _coroutine;

    private void Start() => StartCoroutine(Attack());

    private void Shoot()
    {
        Bullet bullet = GetObject();
        bullet.transform.position = transform.position;
        bullet.gameObject.SetActive(true);
        bullet.SetVelocity(_rigidbody.velocity);
    }

    private IEnumerator Attack()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Shoot();
            yield return wait;
        }
    }
}
