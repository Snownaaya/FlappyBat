using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bat _bat;
    [SerializeField] private EnemyGenerator _enemy;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endScreen;
    [SerializeField] private BulletGenerator _bullet;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.RestartButtonClicked += OnRestartButtonClick;
        _bat.GameOver += StopGame;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.RestartButtonClicked -= OnRestartButtonClick;
        _bat.GameOver -= StopGame;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        StartGame();
        _endScreen.Close();
    }

    private void OnPlayButtonClick()
    {
        StartGame();
        _startScreen.Close();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bat.Reset();
        _enemy.Reset();
        _bullet.Reset();
    }
}
