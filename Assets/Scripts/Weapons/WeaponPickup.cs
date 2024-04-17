using UnityEngine;

public class WeaponPickup : AbstractPickup
{
    [SerializeField] Weapon weapon;

    protected override void Equip(GameObject newOwner)
    {
        WeaponUser weaponUser = newOwner.gameObject.GetComponent<WeaponUser>();
        if(weaponUser == null) return;

        weaponUser.EquipWeapon(weapon);
        base.Equip(newOwner);
    }
}
