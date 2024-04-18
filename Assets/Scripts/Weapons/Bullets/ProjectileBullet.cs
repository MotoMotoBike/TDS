using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileBullet : MonoBehaviour
{
    [SerializeField] float lifeTime;
    [SerializeField] int damage;
    GameObject _owner;
    
    public void Init(GameObject owner){
        _owner = owner;
    }

    public UnityEvent OnDestroy;

    void Start(){
        Invoke(nameof(DestroyAfterDelay), lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == _owner) return;
        
        Health health;
        collision.gameObject.TryGetComponent(out health);
        health?.DealDamage((uint)damage);
        OnDestroy?.Invoke();
        Invoke(nameof(DestroyAfterDelay),2f);
    }

    void DestroyAfterDelay(){
        
        Destroy(gameObject);
    }
}
