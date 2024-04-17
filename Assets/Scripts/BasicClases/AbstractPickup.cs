using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class AbstractPickup : MonoBehaviour
{

    public UnityEvent OnEquipped;
    [SerializeField] float lifeTime;
    private float _timeSinceSpawn;
    internal bool IsEquipped;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(IsEquipped) return;
        Equip(other.gameObject);
    }

    void Update(){
        if(IsEquipped) return;

        _timeSinceSpawn += Time.deltaTime;
        if(_timeSinceSpawn >= lifeTime){
            Destroy(gameObject);
        }
    }

    protected virtual void Equip(GameObject newOwner)
    {
        GetComponent<SpriteRenderer>().sprite = null;
        IsEquipped = true;
    }
}
