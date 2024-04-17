using UnityEngine;
using UnityEngine.Events;

public class WeaponUser : MonoBehaviour
{
    [SerializeField] protected Weapon currentWeapon;
    [SerializeField] public Transform gunPort;
    public UnityEvent OnShoot;

    public void EquipWeapon(Weapon weapon)
    {
        if(currentWeapon != null) currentWeapon.UnEquip();
        
        currentWeapon = weapon;
    }

    public void TryToFire()
    {
        if (currentWeapon != null)
        {
            if(currentWeapon.TryToFire(gunPort))
            OnShoot?.Invoke();
        }
    }
}
