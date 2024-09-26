using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoOpen(bool toOpen)
    {
        animator.SetBool("isOpen", toOpen);
    }
}
