public class PlayerShooter : BulletGenerator
{
    private void Update()
    {
        if (PlayerInput.GetShot())
        Fire();
    }
}