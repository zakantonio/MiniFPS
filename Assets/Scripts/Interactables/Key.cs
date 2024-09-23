using System;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    public string Prompt
    {
        get { return "Una chiave"; }
    }

    public void Interact()
    {

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