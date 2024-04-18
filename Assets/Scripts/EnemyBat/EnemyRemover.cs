using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    [SerializeField] private EnemyGenerator _enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemy.ReturnObject(enemy);
        }
    }
}
