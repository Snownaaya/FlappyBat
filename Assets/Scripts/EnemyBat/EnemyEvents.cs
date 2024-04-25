using System; 

public static class EnemyEvents
{
    public static event Action EnemyDestroyed;

    public static void OnEnemyDestroyed()
    {
        EnemyDestroyed?.Invoke();
    }
}
