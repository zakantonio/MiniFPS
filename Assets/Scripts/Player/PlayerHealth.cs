using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable, IHealable
{
    private int _currentHealthValue;
    int currentHealth
    {
        get => _currentHealthValue;
        set
        {
            value = Mathf.Clamp(value, 0, HealthMax);
            _currentHealthValue = value;

            UiManager.Instance.SetHealthSlider(value);
        }
    }
    private int _currentShieldValue;
    int currentShield
    {
        get => _currentShieldValue;
        set
        {
            value = Mathf.Clamp(value, 0, ShieldMax);
            _currentShieldValue = value;

            UiManager.Instance.SetShieldSlider(value);
        }
    }

    public int HealthMax => 100;
    public int ShieldMax => 100;

    public bool IsAlive => currentHealth > 0;
    public float HealthPercentage => currentHealth / HealthMax * 100;

    public bool HasShield => currentShield > 0;

    void Start()
    {
        ResurrectLikeAJesus();
    }

    public void TakeDamage(int damage)
    {
        int diffShield = damage - currentShield;

        currentShield -= damage;

        if (diffShield > 0)
        {
            currentHealth -= diffShield;
        }

        if (currentHealth <= 0)
        {
            Player.Instance.OnDead();
        }
    }

    public void HandleHeal(int healAmount)
    {
        currentHealth += healAmount;
    }

    public void ResurrectLikeAJesus()
    {
        currentHealth = HealthMax;
        currentShield = ShieldMax;
    }
}
