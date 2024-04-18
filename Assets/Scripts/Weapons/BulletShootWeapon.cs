using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class BulletShootWeapon : Weapon
{
    [SerializeField] private ProjectileBullet bullet;

    [SerializeField] private float _reloadTime;
    [SerializeField] private float _sleepTime;
    [SerializeField] private int _magazineSize;
    [SerializeField] private int amoCount;
    
    public UnityEvent<string> OnAmoChanged;
    public UnityEvent OnFire;
    public UnityEvent<float> OnReloadStarted;
    public UnityEvent OnReloadFinished;
    


    public int _amoInMagazine;

    private bool _isOnReload;
    private bool _isSleeping;

    public override void Equip()
    {
        var hpBar = FindObjectsOfType<Text>().First(e => e.CompareTag("AmoCount"));
        OnAmoChanged.AddListener(e => { hpBar.text = e.ToString(); });
        OnAmoChanged?.Invoke($"{_amoInMagazine}/{_magazineSize}\n{amoCount}");
    }
    public void Start(){
        _amoInMagazine = _magazineSize;
    }

    public override bool TryToFire(Transform gunPort)
    {
        if(_isSleeping || _isOnReload) return false;

        var b = Instantiate(bullet, gunPort.position, gunPort.rotation);
        b.Init(gunPort.parent.gameObject);
        OnFire?.Invoke();
        _amoInMagazine--;
        OnAmoChanged?.Invoke($"{_amoInMagazine}/{_magazineSize}\n{amoCount}");
        _isSleeping = true;
        Invoke(nameof(Sleep), _sleepTime);
        
        StartReloadIfNeed();
        return true;
    }

    public void StartReloadIfNeed(){
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
        OnReloadFinished?.Invoke();
        OnAmoChanged?.Invoke($"{_amoInMagazine}/{_magazineSize}\n{amoCount}");
        _isOnReload = false;
    }
}
