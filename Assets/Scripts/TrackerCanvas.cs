using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TrackerCanvas : MonoBehaviour
{
    Player player =>Player.Instance ;

    [SerializeField] Slider slider;

    void Start () {
       // slider = GetComponentInChildren<Slider>();
    }

    void Update()
    {
        HandleTrack(player.transform);
    }

    public void HandleTrack(Transform target)
    {
        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), Vector3.down);
    }

    public void SetHealth(float damage) {
        slider.value = damage;
    }

}
