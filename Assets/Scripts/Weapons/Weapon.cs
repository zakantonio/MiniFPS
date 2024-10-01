using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IInteractable
{

    WeaponManager weaponManager;
    public string weaponName = "Weapon";
    public int maxAmmo = 30;
    public float fireRate = 0.5f; // m/s
    public int currentAmmo;

    public int damage = 5;

    public int distance = 30;

    public float reloadTime = 2;

    bool isReloading = false;

    Coroutine shootCoroutine;

    Coroutine reloadCoroutine;

    public bool isTaken = false;
    public bool isOnHand = false;

    public GameObject bulletHitPrefab;

    // Start is called before the first frame update
    void Start()
    {
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

        nextTimeToFire = 0;
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
        if (TryRaycast(transform, distance, out IDamageable damageable))
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

    IEnumerator ShowBulletHit(Vector3 point, Collider collider)
    {
        GameObject hit = Instantiate(bulletHitPrefab);
        Vector3 hitPosition = point;
        hit.transform.position = hitPosition;
        hit.transform.LookAt(Player.Instance.transform);

        hitPosition.x += Random.Range(-0.2f, 0.2f);
        hitPosition.y += Random.Range(-0.2f, 0.2f);
        hitPosition.z += Random.Range(-0.2f, 0.2f);

        // Calcola la direzione verso il player
        Vector3 directionToPlayer = (Player.Instance.transform.position - hitPosition).normalized;

        // Distanza per spostare l'oggetto verso il player
        float offsetDistance = 1.0f;  // Cambia questo valore per controllare quanto vicino al player spostare l'oggetto

        // Sposta l'oggetto più vicino al player lungo la direzione calcolata
        hit.transform.position += directionToPlayer * offsetDistance;

        yield return new WaitForSeconds(0.5f);
        Destroy(hit);
    }

    bool TryRaycast(Transform transform, float distance, out IDamageable damageable)
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, distance))
        {
            if (hitInfo.collider.TryGetComponent(out IDamageable other))
            {
                StartCoroutine(ShowBulletHit(hitInfo.point, hitInfo.collider));
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
