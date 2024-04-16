using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AbstractPickup : MonoBehaviour
{

    UnityEvent OnEquiped;
    [SerializeField] float _lifeTime;
    float _timeSinceSpawn;
    bool _isEquiped = false;
    
    void Update(){
        if(_isEquiped) return;

        _timeSinceSpawn += Time.deltaTime;
        if(_timeSinceSpawn >= _lifeTime){
            Destroy(gameObject);
        }
    }

    public virtual void Equip(){
        //_isEquiped = true;
    }
}
