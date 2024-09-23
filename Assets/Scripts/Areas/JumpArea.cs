using UnityEngine;

public class JumpArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerMotor playerMotor))
        {
            playerMotor.HandleJump(5f);
        }
    }
}
