using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _score;

    private void OnEnable() => _scoreCounter.ScoreChanged += OnValueChanged;

    private void OnDisable() => _scoreCounter.ScoreChanged -= OnValueChanged;

    private void OnValueChanged(int score) =>
        _score.text = score.ToString();
}
