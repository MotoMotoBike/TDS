using UnityEngine;


public class WeaponUser : MonoBehaviour
{
    [SerializeField] protected Weapon currentWeapon;
    [SerializeField] public Transform gunPort;

    public void EquipWeapon(Weapon weapon)
    {
        if(currentWeapon != null) currentWeapon.UnEquip();
        
        currentWeapon = weapon;
    }

    public bool TryToFire()
    {
        if (currentWeapon != null)
        {
            return currentWeapon.TryToFire(gunPort);
        }
        return false;
    }
}
