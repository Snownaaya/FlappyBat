using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _delay = 1f;

    private EnemyBulletSpawner _bulletSpawner;
    private Coroutine _coroutine;

    private void Start() => _coroutine = StartCoroutine(Attack());

    public void SetObjectRemover(EnemyBulletSpawner objectRemover) => _bulletSpawner = objectRemover;

    public IEnumerator Attack()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _bulletSpawner.Shoot();
            yield return wait;
        }
    }
}
