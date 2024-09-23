using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IInteractable
{

    UiManager uiManager;
    WeaponManager weaponManager;
    public string weaponName = "Weapon";
    public int maxAmmo = 30;
    public float fireRate = 0.5f; // m/s
    public int currentAmmo;

    public int damage = 5;

    public int range = 10;

    public float reloadTime = 2;

    bool isReloading = false;

    Coroutine shootCoroutine;

    Coroutine reloadCoroutine;

    public bool isTaken = false;
    public bool isOnHand = false;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = UiManager.Instance;
        weaponManager = WeaponManager.Instance;

        SetParameters();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void SetParameters()
    {

    }

    float nextTimeToFire;

    public void HandleShoot(Transform transform)
    {
        if (!isReloading && currentAmmo > 0 && (Time.time >= nextTimeToFire))
        {
            shootCoroutine = StartCoroutine(ShootRoutine(transform));

            nextTimeToFire = Time.time + 1f / fireRate;
        }
    }

    public void HandleStopShoot()
    {
        if (shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
        }
    }

    public void HandleReload()
    {
        if (!isReloading && currentAmmo < maxAmmo && WeaponManager.Instance.GetBulletAmount(this) > 0)
        {
            reloadCoroutine = StartCoroutine(ReloadRoutine());

            if (shootCoroutine != null)
            {
                StopCoroutine(shootCoroutine);
            }
        }
    }

    public void HandleStopReload()
    {
        if (reloadCoroutine != null)
        {
            StopCoroutine(reloadCoroutine);
        }
    }

    IEnumerator ShootRoutine(Transform transform)
    {
        currentAmmo--;
        if (TryRaycast(transform, range, out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
        }
        yield return new WaitForSeconds(fireRate);

        if (currentAmmo > 0)
        {
            shootCoroutine = StartCoroutine(ShootRoutine(transform));
        }
    }

    IEnumerator ReloadRoutine()
    {
        isReloading = true;
        UiManager.Instance.SetIsReloading(true);
        yield return new WaitForSeconds(reloadTime);
        int availableBullets = weaponManager.GetBulletAmount(this);
        if (availableBullets < maxAmmo)
        {
            currentAmmo = availableBullets;
        }
        else
        {
            currentAmmo = maxAmmo;
        }
        weaponManager.OnReloaded(this, currentAmmo);
        UiManager.Instance.SetIsReloading(false);
        isReloading = false;

    }

    static bool TryRaycast(Transform transform, float distance, out IDamageable damageable)
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, distance))
        {
            if (hitInfo.collider.TryGetComponent(out IDamageable other))
            {
                damageable = other;
                return true;
            }
        }
        damageable = null;
        return false;
    }

    public string Prompt => isTaken ? "" : "Press ALT to get";

    public void Interact()
    {
        WeaponManager.Instance.HandleAddWeapon(this);
    }
}
