using UnityEngine;

namespace Weapons
{
    public class BulletShootWeapon : Weapon
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField]
        public override void TryToFire(Transform gunPort)
        {
            Instantiate(bulletPrefab,gunPort.position,gunPort.rotation);
        }
    }
}