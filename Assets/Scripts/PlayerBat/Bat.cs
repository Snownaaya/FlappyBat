using UnityEngine;
using System;

[RequireComponent(typeof(BatMover))]
[RequireComponent(typeof(BatCollisionHandler))]
public class Bat : MonoBehaviour, IResettable
{
    private BatMover _batMover;
    private BatCollisionHandler _handler;
    private ScoreCounter _scoreCounter;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _batMover = GetComponent<BatMover>();
        _handler = GetComponent<BatCollisionHandler>();
    }

    private void OnEnable() => _handler.CollisionDetected += ProcessColision;

    private void OnDisable() => _handler.CollisionDetected -= ProcessColision;

    public void Reset()
    {
        _scoreCounter.Reset();
        _batMover.Reset();
    }

    private void ProcessColision(IInteractable interactable)
    {
        if (interactable is Enemy or EnemyBullet)
            GameOver?.Invoke();

        if (interactable is ScoreZone)
            _scoreCounter.Add();
    }
}
