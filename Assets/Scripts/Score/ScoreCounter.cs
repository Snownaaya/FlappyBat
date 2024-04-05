using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour, IResettable
{
    private int _score = 0;

    public UnityEvent<int> ScoreChanged;

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
