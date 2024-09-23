using System;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    Animator animator;

    void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }
    public void Interact()
    {
        animator.SetBool("isOpen", !animator.GetBool("isOpen"));
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string Prompt
    {
        get { return "Una porta"; }
    }

}