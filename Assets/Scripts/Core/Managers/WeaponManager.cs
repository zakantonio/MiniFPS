using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{

    Camera mainCamera;

    List<Weapon> weapons = new();

    Weapon currentWeapon;

    [SerializeField] GameObject weaponSpot;

    int bulletAmount = 0;

    void Start()
    {

        mainCamera = gameObject.GetComponentInChildren<Camera>();
        foreach (Weapon w in weapons)
        {
            Enable(w, false);
        }

        if (weapons.Count > 0)
        {
            currentWeapon = weapons[0];
            Enable(currentWeapon, true);
            
        }
        
        UpdateUi();

    }

    public void SwitchWeapon()
    {
        if (weapons.Count == 0) return;

        int pos = weapons.IndexOf(currentWeapon);

        Enable(currentWeapon, false);
        if (pos == weapons.Count - 1)
        {
            currentWeapon = weapons[0];
        }
        else
        {
            currentWeapon = weapons[pos + 1];
        }
        Enable(currentWeapon, true);


        UpdateUi();
    }

    public int GetBulletAmount(Weapon weapon)
    {
        // TODO switch to get correct bullet based on type of weapon
        return bulletAmount;
    }

    public void OnShooted(Weapon weapon)
    {
        // TODO switch to decrease correct bullet based on type of weapon
        bulletAmount--;


        UpdateUi();
    }

    public void OnReloaded(Weapon weapon, int amount)
    {
        // TODO switch to decrease correct bullet based on type of weapon
        bulletAmount -= amount;

        UpdateUi();
    }

    public void HandleShoot()
    {
        if (currentWeapon != null)
            currentWeapon.HandleShoot(mainCamera.transform);


        UpdateUi();
    }

    public void HandleStopShoot()
    {
        if (currentWeapon != null)
            currentWeapon.HandleStopShoot();


        UpdateUi();
    }

    public void HandleReload()
    {
        if (currentWeapon != null)
            currentWeapon.HandleReload();


        UpdateUi();
    }

    void Enable(Weapon weapon, bool isToEnable)
    {
        if (weapon == null) return;
        weapon.gameObject.SetActive(isToEnable);
    }

    public void HandleAddWeapon(Weapon weapon)
    {
        weapon.transform.parent = weaponSpot.transform;

        weapon.transform.localPosition = new Vector3(0, 0, 0);
        weapon.transform.rotation = new Quaternion(0, 0, 0, 0);
        weapon.transform.localScale = new Vector3(1, 1, 1);

        weapon.isTaken = true;
        weapons.Add(weapon);

        if (currentWeapon == null)
        {
            weapon.HandleReload();
            currentWeapon = weapon;
        }
        else
        {
            Enable(weapon, false);
        }
        UpdateUi();
    }

    public void HandleAddBullet(int amount)
    {
        bulletAmount += amount;
        UpdateUi();
    }

    void UpdateUi()
    {

        if (currentWeapon != null)
            UiManager.Instance.SetWeaponInfo(currentWeapon.weaponName, currentWeapon.currentAmmo, currentWeapon.maxAmmo, bulletAmount);
            else {
                 UiManager.Instance.SetWeaponInfo("No weapon", 0, 0, bulletAmount);
            }
    }
}