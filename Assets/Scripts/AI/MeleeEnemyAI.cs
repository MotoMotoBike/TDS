using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Rotation))]
public class MeleeEnemyAI : EnemyAI
{
    public UnityEvent OnAttack;
    
    private Movement _movement;
    private Rotation _rotation;

    [SerializeField] private float maxTimeToChangeWalkDirection;
    [SerializeField] private float minTimeToChangeWalkDirection;
    [SerializeField] private float rayCount;
    [SerializeField] private float sphereCastRadius;
    
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackDelay; // Правильнее использовать класс WeaponUser, но не успею к дедлайну
    [SerializeField] private float attackDamage; // Правильнее использовать класс WeaponUser, но не успею к дедлайну
    private bool _isAttackReady = true;
    private void Start()
    {
        _movement = GetComponent<Movement>();
        _rotation = GetComponent<Rotation>();
        MoveAtRandomDirection();
    }

    internal override bool TryToFindTarget()
    {
        float angleStep = 360f / rayCount;

        for (int i = 0; i < rayCount; i++)
        {
            float angle = i * angleStep;
            Vector2 direction = Quaternion.AngleAxis(angle, Vector3.forward)  * Vector2.right;
            
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, sphereCastRadius, direction, 30);
            GameObject playerGO;
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("Игрок найден!");
                target = hit.collider.gameObject;
                return true;
            }
        }
        return false;
    }

    private void FixedUpdate()
    {
        if (status != Status.Harassment) return;
        if (target == null) return;

        var targetPosition = target.transform.position;

        _rotation.RotateAtDirection(( targetPosition - transform.position).normalized);
        _movement.MoveAtDirection(( targetPosition - transform.position).normalized);
        
        if (_isAttackReady && Vector2.Distance(targetPosition, transform.position) < attackRadius) Attack();
    }

    internal override void Attack()
    {
        status = Status.Attack;
        var hits =Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);
        var player = hits.Where(h => h.CompareTag("Player")).Select(h => h.GetComponent<Health>()).FirstOrDefault();
        player?.DealDamage((uint)attackDamage);
        _isAttackReady = false;
        OnAttack?.Invoke();
        Invoke(nameof(Reload),attackDelay);
    }

    internal void Reload()
    {
        _isAttackReady = true;
        status = Status.Harassment;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        MoveAtRandomDirection();
    }

    void MoveAtRandomDirection()
    {
        CancelInvoke(nameof(MoveAtRandomDirection));

        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        _movement.MoveAtDirection(direction);
        _rotation.RotateAtDirection(direction);
        
        if (TryToFindTarget())
        {
            status = Status.Harassment;
        }
        else
        {
            status = Status.Searching;
            Invoke(nameof(MoveAtRandomDirection),
                Random.Range(minTimeToChangeWalkDirection, maxTimeToChangeWalkDirection));
        }
    }


    // GIZMOS------------------------------
    void OnDrawGizmosSelected()
    {
        float angleStep = 360f / rayCount;
        for (int i = 0; i < rayCount; i++)
        {
            float angle = i * angleStep;
            Vector2 direction = Quaternion.AngleAxis(angle, Vector3.forward)  * Vector2.right;

            Gizmos.color = Color.red;
            var position = transform.position;
            Gizmos.DrawRay(position, direction * 30);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere((direction * 10) + (Vector2)position, sphereCastRadius);
        }
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}