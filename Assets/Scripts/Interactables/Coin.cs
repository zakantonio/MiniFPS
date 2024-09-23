using System;
using UnityEngine;

public class Coin : MonoBehaviour, IInteractable
{
    

    public string Prompt => "Press ALT to get";

    public void Interact()
    {
        GameManager.Instance.AddCoin();
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }


}