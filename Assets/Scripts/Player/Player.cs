using UnityEngine;

public class Player : Singleton<Player>
{
    void Start()
    {
        GoToCheckpoint();
    }

    public void OnDead()
    {
        GoToCheckpoint();

        // if (--GameManager.Instance.currentLives > 0)
            GetComponent<PlayerHealth>().ResurrectLikeAJesus();
    }

    public void GoToCheckpoint()
    {
        Vector3 currentCheckPoint = GameManager.Instance.currentCheckPoint;
        gameObject.transform.position = currentCheckPoint;

    }
}

