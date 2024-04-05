using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _score;

    private void OnEnable() => _scoreCounter.ScoreChanged.AddListener(score => _score.text = score.ToString());

    private void OnDisable() => _scoreCounter.ScoreChanged.RemoveListener(score => _score.text = score.ToString());
}
