using System.Collections;
using UnityEngine;

public class EnemyGenerator : ObjectPool<Enemy>
{
    [SerializeField] private float _minSpawnPosition;
    [SerializeField] private float _maxSpawnPosition;
    [SerializeField] EnemyBulletSpawner _bulletSpawner;

    private Coroutine _coroutine;

    private float _delay = 2f;

    private void Start() => _coroutine = StartCoroutine(GenerateEnemies());

    private IEnumerator GenerateEnemies()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;
            Spawn();
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_minSpawnPosition, _maxSpawnPosition);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy enemyPool = GetObject();
        enemyPool.GetComponent<EnemyShooter>().SetObjectSpawner(_bulletSpawner);
        enemyPool.transform.position = spawnPoint;
        enemyPool.gameObject.SetActive(true);
    }
}
