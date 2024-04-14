using UnityEngine;
using System.Collections;

public class EnemyBulletSpawner : ObjectPool<Bullet>
{
    private float _delay = 1f;

    private Coroutine _coroutine;

    private void Start() => _coroutine = StartCoroutine(Attack());

    private IEnumerator Attack()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Shoot();
            yield return wait;
        }
    }

    private void Shoot()
    {
        Bullet bullet = GetObject();
        bullet.transform.position = transform.position;
        bullet.gameObject.SetActive(true);
    }
}
