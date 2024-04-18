using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    int _currentHealth;
    public UnityEvent<float> OnHealthChanged;
    public UnityEvent OnDeath;

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public void DealDamage(uint damageAmount)
    {
        _currentHealth -= (int)damageAmount;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
        OnHealthChanged?.Invoke( _currentHealth/ (float)maxHealth);
    }
    public void Heal(int healAmount)
    {
        _currentHealth += healAmount;
        if (_currentHealth > maxHealth)
        {
            _currentHealth = maxHealth;
        }
        OnHealthChanged.Invoke(_currentHealth / (float)maxHealth);
    }
}
    