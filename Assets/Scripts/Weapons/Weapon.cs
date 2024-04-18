using UnityEngine;


public abstract class Weapon : MonoBehaviour
{
    public abstract bool TryToFire(Transform gunPort);
    public abstract void Equip();

    public void UnEquip()
    {
        Destroy(gameObject);
    }
}
