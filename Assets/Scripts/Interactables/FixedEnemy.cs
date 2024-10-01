using UnityEngine;

public class FixedEnemy : MonoBehaviour
{

    EnemyDamageable damageable;

    TrackerCanvas trackerCanvas;

    public GameObject coinGO;

    // Start is called before the first frame update
    void Start()
    {

        damageable = GetComponentInChildren<EnemyDamageable>();
        damageable.onDamage(damageable =>
        {
            if (!damageable.IsAlive)
            {
                GameObject coin = Instantiate(coinGO);
                Vector3 tempPos = gameObject.transform.position;
                tempPos.y = 1.5f;
                coin.transform.position = tempPos;
                Destroy(gameObject);
            }
            print(damageable.HealthPercentage);
            trackerCanvas.SetHealth(damageable.HealthPercentage);
        });


        trackerCanvas = GetComponentInChildren<TrackerCanvas>();
        trackerCanvas.SetHealth(damageable.HealthPercentage);
    }



}