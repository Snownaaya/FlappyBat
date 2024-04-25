using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour, IResettable
{
    [SerializeField] Enemy _enemy;

    private int _score = 0;

    public Action<int> ScoreChanged;

    private void OnEnable() => _enemy.EnemyDestroyed += Add;

    private void OnDisable() => _enemy.EnemyDestroyed -= Add;

    public void Add()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}