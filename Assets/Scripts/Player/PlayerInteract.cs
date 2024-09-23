using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    Camera mainCamera;

    float distance = 4f;

    void Awake()
    {
        mainCamera = GetComponentInChildren<Camera>();
    }
    // Start is called before the first frame update
    void Start()
    {

        UiManager.Instance.SetPrompt("");
    }

    // controllo costantemente contro quale oggetto sto puntando
    // Update is called once per frame
    void Update()
    {
        HandlePrompt();
    }

    public void HandlePrompt()
    {

        if (MyUtils.TryRaycast(mainCamera.transform.position, mainCamera.transform.forward, distance,out RaycastHit hitInfo, out IInteractable other))
        {
            UiManager.Instance.SetPrompt(other.Prompt);
        }
        else
        {
            UiManager.Instance.SetPrompt("");

        }
    }

    public void HandleInteract()
    {

        if (MyUtils.TryRaycast(mainCamera.transform.position, mainCamera.transform.forward, distance, out RaycastHit hitInfo, out IInteractable other))
        {
            other.Interact();
        }
    }

}
