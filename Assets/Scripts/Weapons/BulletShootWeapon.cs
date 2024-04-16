using UnityEngine;
using UnityEngine.Events;


public class BulletShootWeapon : Weapon
{
    [SerializeField] private ProjectileBullet bullet;

    [SerializeField] private float _reloadTime;
    [SerializeField] private float _sleepTime;
    [SerializeField] private int _magazineSize;
    [SerializeField] private int amoCount;
    
    public UnityEvent OnFire;
    public UnityEvent<float> OnReloadStarted;
    public UnityEvent OnReloadFinished;
    


    public int _amoInMagazine;

    bool _isOnReload = false;
    bool _isSleeping = false;

    public void Start(){
        _amoInMagazine = _magazineSize;
    }

    public override void TryToFire(Transform gunPort)
    {
        if(_isSleeping || _isOnReload) return;

        var b = Instantiate(bullet, gunPort.position, gunPort.rotation);
        b.Init(this.gameObject);
        OnFire?.Invoke();
        _amoInMagazine--;
        _isSleeping = true;
        Invoke(nameof(Sleep), _sleepTime);
        
        ReloadIfNeed();
    }

    public void ReloadIfNeed(){
        if(_amoInMagazine == 0){

            if(amoCount == 0){
                Destroy(this);
            }
            _isOnReload = true;
            OnReloadStarted?.Invoke(_reloadTime);
            Invoke(nameof(Reload), _reloadTime);
        }
    }

    public void Sleep(){
        _isSleeping = false;
    }

    public void Reload(){
        amoCount -=_magazineSize;
        _amoInMagazine = _magazineSize;
        if(amoCount < 0){
            _amoInMagazine += amoCount;
            amoCount = 0;
        }
        _isOnReload = false;
    }
}
