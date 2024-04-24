using System.Collections;
using UnityEngine;

public class EnemyGenerator : ObjectPool<Enemy>
{
    [SerializeField] private float _minSpawnPosition;
    [SerializeField] private float _maxSpawnPosition;
    [SerializeField] private EnemyBulletSpawner _bulletSpawner;

    private Coroutine _coroutine;

    private float _delay = 2f;

    private void Start() => _coroutine = StartCoroutine(GenerateEnemies());

    private IEnumerator GenerateEnemies()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Enemy enemyPool = GetObject();

            Spawn(enemyPool, _bulletSpawner);

            yield return wait;
        }
    }

    private void Spawn(Enemy enemyPool, EnemyBulletSpawner bulletSpawner)
    {
        enemyPool.GetComponent<EnemyShooter>().SetObjectSpawner(bulletSpawner);

        float spawnPositionY = Random.Range(_minSpawnPosition, _maxSpawnPosition);
        enemyPool.transform.position = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        enemyPool.gameObject.SetActive(true);
    }
}
