using System.Collections;
using UnityEngine;

public class DamageArea : MonoBehaviour
{

    int damage = 10;
    Coroutine coroutine;


    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
           // coroutine = StartCoroutine(AttackPlayer(damageable));
        }
    }
    void OnTriggerExit(Collider other)
    {
       if (coroutine != null) StopCoroutine(coroutine);
    }

    IEnumerator AttackPlayer(IDamageable damageable)
    {
        damageable.TakeDamage(damage);

        yield return new WaitForSeconds(1f);

        coroutine = StartCoroutine(AttackPlayer(damageable));
    }
}

