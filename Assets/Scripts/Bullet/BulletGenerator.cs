using System.Collections;
using UnityEngine;

public abstract class BulletGenerator : MonoBehaviour
{
    [SerializeField] private ObjectPool<Bullet> _bulletPool;

    private Coroutine _coroutine;
    private float _delay = 1f;

    public IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    protected void Spawn()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Bullet bullet = _bulletPool.GetObject();
        bullet.gameObject.SetActive(true);

        bullet.transform.position = position;
    }
}
