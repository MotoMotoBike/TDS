using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract void TryToFire(Transform gunPort);
    }

}