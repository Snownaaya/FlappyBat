using UnityEngine;

public class PlayerBullet : BulletGenerator
{
    private void Update()
    {
        if (PlayerInput.GetShot())
            Shooter();
    }
}