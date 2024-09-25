using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {

        if (other.TryGetComponent<Player>(out Player player)) {
            Vector3 pos = gameObject.transform.parent.position;
            GameManager.Instance.currentCheckPoint = pos;
            Destroy(gameObject);
        }
    }
}
