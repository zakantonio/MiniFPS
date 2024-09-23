using UnityEngine;


public enum BoxContent
{
    Coin,
    Ammo,
    M1911,
    AK47,
    M249,
    Bennelli,
    Uzi,
    Bomb

}

public class BoxBehaviour : MonoBehaviour, IInteractable
{

    [SerializeField] BoxContent content;

    [SerializeField] GameObject contentSpot;

    Animator animator;

    bool isOpened = false;

    public string Prompt => isOpened ? "" : "Press ALT to open";

    public void Interact()
    {
        animator.SetTrigger("doOpen");
        isOpened = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();

        foreach (Transform t in contentSpot.transform)
        {
            t.gameObject.SetActive(false);
        }


        switch (content)
        {
            case BoxContent.Coin:
                {
                    EnableContent<Coin>();
                    break;
                }
            case BoxContent.Ammo:
                {
                    EnableContent<BulletSet>();
                    break;
                }
            case BoxContent.M1911:
                {
                    EnableContent<M1911Weapon>();
                    break;
                }
            case BoxContent.Uzi:
                {
                    EnableContent<UziWeapon>();
                    break;
                }
            case BoxContent.AK47:
                {
                    EnableContent<AK47Weapon>();
                    break;
                }
            case BoxContent.M249:
                {
                    EnableContent<M249Weapon>();
                    break;
                }
            case BoxContent.Bennelli:
                {
                    EnableContent<BennelliM4Weapon>();
                    break;
                }
            case BoxContent.Bomb:
                {
                    EnableContent<RGD5Weapon>();
                    break;
                }
        }
    }

    void EnableContent<T>() where T : MonoBehaviour
    {
        foreach (Transform t in contentSpot.transform)
        {
            if (t.gameObject.TryGetComponent(out T content))
            {
                content.gameObject.SetActive(true);

            }
        }
    }
}
