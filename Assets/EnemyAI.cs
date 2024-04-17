using System;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    internal GameObject target;
    internal Status status = Status.Searching;
    internal abstract bool TryToFindTarget();
    internal abstract void Attack();

    internal enum Status
    {
        Searching,
        Harassment,
        Attack
    }
    
}
