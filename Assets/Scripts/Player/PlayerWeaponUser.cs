using System;
using Weapons;

namespace Player
{
    public class PlayerWeaponUser : WeaponUser
    {
        private void FixedUpdate()
        {
            TryToFire();
        }
    }
}