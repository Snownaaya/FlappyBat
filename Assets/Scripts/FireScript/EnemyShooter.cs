using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _delay = 1f;

    private EnemyBulletSpawner _bulletSpawner;
    private Coroutine _coroutine;

    private void Start() => _coroutine = StartCoroutine(Attack());

    public void SetObjectSpawner(EnemyBulletSpawner objectSpawner) => _bulletSpawner = objectSpawner;

    public IEnumerator Attack()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _bulletSpawner.SpawnBullet(transform.position);
            yield return wait;
        }
    }
}
