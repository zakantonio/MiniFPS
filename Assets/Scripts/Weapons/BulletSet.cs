using UnityEngine;

public class BulletSet : MonoBehaviour, IInteractable
{
    public string Prompt => "Press ALT to get";

    int bulletAmount = 50;
    public void Interact()
    {
        WeaponManager.Instance.HandleAddBullet(bulletAmount);
        Destroy(gameObject);
    }
}
