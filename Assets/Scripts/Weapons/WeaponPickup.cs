using UnityEngine;

public class WeaponPickup : AbstractPickup
{
    [SerializeField] Weapon weapon;

    protected override void Equip(GameObject newOwner)
    {
        base.Equip(newOwner);
        WeaponUser weaponUser = newOwner.gameObject.GetComponent<WeaponUser>();
        if(weaponUser == null) return;

        weaponUser.EquipWeapon(weapon);
    }
}
