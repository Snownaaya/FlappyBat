using UnityEngine;
using System;

[RequireComponent(typeof(BatMover))]
[RequireComponent(typeof(BatCollisionHandler))]
public class Bat : MonoBehaviour, IResettable
{
    private BatMover _batMover;
    private BatCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _batMover = GetComponent<BatMover>();
        _handler = GetComponent<BatCollisionHandler>();
    }

    private void OnEnable() => _handler.CollisionDetected += ProcessColision;

    private void OnDisable() => _handler.CollisionDetected -= ProcessColision;

    public void Reset()
    {
        _batMover.Reset();
    }

    private void ProcessColision(IInteractable interactable)
    {
        if (interactable is Enemy or EnemyBullet)
            GameOver?.Invoke();
    }
}
