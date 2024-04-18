using UnityEngine;
using System;

public class Enemy : MonoBehaviour, IInteractable
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerBullet bullet))
            Destroy(gameObject);
    }
}