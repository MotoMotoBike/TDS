using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileBullet : MonoBehaviour
{
    [SerializeField] float _lifeTime;
    GameObject _owner;
    
    public void Init(GameObject owner){
        _owner = owner;
    }

    public UnityEvent OnDestroy;

    void Start(){
        Invoke(nameof(DestroyBullet), _lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject != _owner)
            DestroyBullet();
    }

    IEnumerator DestroyAfterDelay(){
        Hide();
        OnDestroy?.Invoke();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    void Hide(){
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<SpriteRenderer>().enabled = false; 
        GetComponent<Movement>().enabled = false;
    }
    void DestroyBullet(){
        StartCoroutine(nameof(DestroyAfterDelay));
    }
}
