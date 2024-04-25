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

    private void Spawn(Enemy enemy)
    {
        float spawnPositionY = Random.Range(_minSpawnPosition, _maxSpawnPosition);
        enemy.transform.position = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        enemy.gameObject.SetActive(true);
        enemy.SetupShooter(_bulletSpawner);
    }

    private IEnumerator GenerateEnemies()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Enemy enemyPool = GetObject();

            Spawn(enemyPool);

            yield return wait;
        }
    }
}
