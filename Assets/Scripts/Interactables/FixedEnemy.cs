using UnityEngine;

public class FixedEnemy : MonoBehaviour
{

    EnemyDamageable damageable;

    TrackerCanvas trackerCanvas;

    // Start is called before the first frame update
    void Start()
    {

        damageable = GetComponentInChildren<EnemyDamageable>();
        damageable.onDamage(damageable =>
        {
            if (!damageable.IsAlive)
            {
                Destroy(gameObject);
            }
            trackerCanvas.SetHealth(damageable.HealthPercentage);
        });
        
        
        trackerCanvas = GetComponentInChildren<TrackerCanvas>();
        trackerCanvas.SetHealth(damageable.HealthPercentage);
    }



}