using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _delay = 2f;
    [SerializeField] private Transform _shotPosition;

    private EnemyBulletSpawner _bulletSpawner;
    private Coroutine _coroutine;

    public void SetObjectSpawner(EnemyBulletSpawner objectSpawner)
    {
        _bulletSpawner = objectSpawner;
        StopAttack();
        _coroutine = StartCoroutine(Attack());
    }

    private void StopAttack()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public IEnumerator Attack()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _bulletSpawner.SpawnBullet(_shotPosition);
            yield return wait;
        }
    }
}