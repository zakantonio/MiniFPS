
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<Player>(out Player player))
        {
            Vector3 pos = gameObject.transform.parent.position;
            GameManager.Instance.currentCheckPoint = pos;
            Destroy(gameObject);
        }
    }
}
