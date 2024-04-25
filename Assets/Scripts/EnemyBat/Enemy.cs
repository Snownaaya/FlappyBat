using UnityEngine;
using System;

public class Enemy : MonoBehaviour, IInteractable 
{
    [SerializeField] private EnemyShooter _shooter;

    public event Action EnemyDestroyed;

    public void SetupShooter(EnemyBulletSpawner bulletSpawner) => _shooter.SetObjectSpawner(bulletSpawner);

    public void OnEnemyDestroyed() => EnemyDestroyed?.Invoke();
}