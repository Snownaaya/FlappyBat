using UnityEngine;

public static class PlayerInput
{
    public static bool GetMove() => Input.GetKeyDown(KeyCode.D);
    
    public static bool GetShot() => Input.GetMouseButton(0);
}
