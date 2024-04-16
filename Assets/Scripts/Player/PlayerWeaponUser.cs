using System;

public class PlayerWeaponUser : WeaponUser
{
    private void FixedUpdate()
    {
        TryToFire();
    }
}
