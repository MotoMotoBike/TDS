using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : AbstractPickup
{
    [SerializeField] Weapon _weapon;
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.GetComponent<WeaponUser>() == null) return;
        
        other.gameObject.GetComponent<WeaponUser>().EquipWeapon(_weapon);
        Equip();
    }
}
