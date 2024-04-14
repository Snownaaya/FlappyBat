using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour, IResettable
{
    private int _score = 0;

    public Action<int> ScoreChanged;

    //public void SetEnemy(Enemy enemy)
    //{
    //    enemy.EnemyDied += Add;
    //}

    //private void OnDisable()
    //{
    //    Enemy enemy = GetComponent<Enemy>();
    //    enemy.EnemyDied -= Add;
    //}

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
