using UnityEngine;

public class ToggleBehaviour : MonoBehaviour, IInteractable
{
    Animator animator;

    bool isOpened = false;

    [SerializeField] WallBehaviour wall;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string Prompt => isOpened ? "Press ALT to close" : "Press ALT to open";

    public void Interact()
    {
        isOpened = !isOpened;
        animator.SetBool("isOpen", isOpened);
        wall.DoOpen(isOpened);
    }
}
