using UnityEngine;


public abstract class WeaponUser : MonoBehaviour
{
    [SerializeField] protected Weapon _currentWeapon;
    [SerializeField] public Transform gunPort;

    public void EquipWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

    public void TryToFire()
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.TryToFire(gunPort);
        }
    }
}
