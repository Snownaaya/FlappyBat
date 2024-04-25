using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour, IResettable
{
    private int _score = 0;

    public Action<int> ScoreChanged;

    private void OnEnable() => EnemyEvents.EnemyDestroyed += Add;

    private void OnDisable() => EnemyEvents.EnemyDestroyed -= Add;

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