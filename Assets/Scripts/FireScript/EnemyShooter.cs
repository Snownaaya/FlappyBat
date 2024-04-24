using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _delay = 2f;
    [SerializeField] private Transform _shotPosition;

    private EnemyBulletSpawner _bulletSpawner;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        StopAttack();

        _coroutine = StartCoroutine(Attack());
    }

    private void OnDisable() => StopAttack();

    public void SetObjectSpawner(EnemyBulletSpawner objectSpawner) => _bulletSpawner = objectSpawner;

    private void StopAttack()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Attack()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _bulletSpawner.SpawnBullet(_shotPosition);
            yield return wait;
        }
    }
}