using System;
using System.Collections;
using UnityEngine;

public class EnemyDamageable : MonoBehaviour, IDamageable
{

    public int HealthMax => 50;
    public int ShieldMax => 0;
    public bool IsAlive => health > 0;
    public float HealthPercentage => health / HealthMax * 100;

    private float health;

    int damage = 50;

    Animator animator;
    Action<IDamageable> onDamageCallback;

    [SerializeField] GameObject gun;

    Coroutine shootRoutine;

    public void TakeDamage(int damage)
    {
        health -= damage;
        onDamageCallback?.Invoke(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        health = HealthMax;

        animator = GetComponent<Animator>();
    }

    public void HandleAnim(bool isTracking)
    {

        animator.enabled = isTracking;

        gun.transform.rotation = new Quaternion(0,0,0,0);
    }

    public void HandleTrack(Transform target)
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));

    }


    public void HandleShoot()
    {
        shootRoutine = StartCoroutine(ShootRoutine());

        HandleAnim(false);
    }

    public void HandleStopShoot()
    {
        if (shootRoutine != null)
        {
            StopCoroutine(shootRoutine);
        }

        HandleAnim(true);
    }

    public void onDamage(Action<IDamageable> onDamage)
    {
        onDamageCallback = onDamage;
    }


    IEnumerator ShootRoutine()
    {

        yield return new WaitForSeconds(2);


        if (MyUtils.TryRaycast(gun.transform.position, Player.Instance.transform.position - gun.transform.position, 20, out RaycastHit hitInfo, out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(damage);
        }

        shootRoutine = StartCoroutine(ShootRoutine());

    }


}