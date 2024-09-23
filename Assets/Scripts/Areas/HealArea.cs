using System.Collections;
using UnityEngine;

public class HealArea : MonoBehaviour
{

    int heal = 5;

    Coroutine coroutine;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHealable healable))
        {
            coroutine = StartCoroutine(HealPlayer(healable));
        }
    }

    void OnTriggerExit(Collider other)
    {
        StopCoroutine(coroutine);
    }

    IEnumerator HealPlayer(IHealable healable)
    {
        healable.HandleHeal(heal);

        yield return new WaitForSeconds(1f);

        coroutine = StartCoroutine(HealPlayer(healable));
    }
}