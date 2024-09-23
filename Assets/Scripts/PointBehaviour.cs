using Unity.Mathematics;
using UnityEngine;

public class PointBehaviour : MonoBehaviour
{

   public CollisionHandler onCollision { get; set; }

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
        Destroy(gameObject);

        onCollision?.Invoke();
    }


}
public delegate void CollisionHandler();