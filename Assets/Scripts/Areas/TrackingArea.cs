
using UnityEngine;

public class TrackingArea : MonoBehaviour
{

    [SerializeField] EnemyDamageable damageable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            damageable.HandleShoot();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            damageable.HandleTrack(player.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        damageable.HandleStopShoot();
    }
}

