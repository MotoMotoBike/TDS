using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    internal GameObject target;
    internal abstract void SearchTarget();
    internal abstract void Attack();
}
