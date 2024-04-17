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
        Invoke(nameof(DestroyBullet), lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == _owner) return;
        
        Health health;
        collision.gameObject.TryGetComponent(out health);
        health?.DealDamage((uint)damage);
        DestroyBullet();
        
    }

    IEnumerator DestroyAfterDelay(){
        TurnOff();
        OnDestroy?.Invoke();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    void TurnOff(){
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Movement>().enabled = false;
    }
    void DestroyBullet(){
        StartCoroutine(nameof(DestroyAfterDelay));
    }
}
