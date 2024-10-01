using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager>
{
    [SerializeField] Slider healthSlider;
    [SerializeField] Slider shieldSlider;
    [SerializeField] Slider staminaSlider;
    [SerializeField] TextMeshProUGUI promptText;
    [SerializeField] TextMeshProUGUI weaponCurrentAmmo;
    [SerializeField] TextMeshProUGUI weaponName;
    [SerializeField] TextMeshProUGUI bulletAmountTex;
    [SerializeField] TextMeshProUGUI isReloadingText;
    [SerializeField] TextMeshProUGUI coinsText;

    public void SetPrompt(String prompt)
    {
        promptText.text = prompt;
    }
    public void SetHealthSlider(int value)
    {
        healthSlider.value = value;
    }
    public void SetShieldSlider(int value)
    {
        shieldSlider.value = value;
    }
    public void SetStaminaSlider(int value)
    {
        staminaSlider.value = value;
    }

    public void SetWeaponInfo(String name, int currentAmmo, int maxAmmo, int bulletAmount)
    {
        weaponCurrentAmmo.text = currentAmmo.ToString() + " / " + maxAmmo;
        weaponName.text = name;
        bulletAmountTex.text = bulletAmount.ToString();
    }

    public void SetIsReloading(bool isReloading)
    {
        isReloadingText.text = isReloading ? "Reloading..." : "";
    }

    public void SetCoins(int coins)
    {
        coinsText.text = coins.ToString();
    }
}