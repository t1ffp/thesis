using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrigger : MonoBehaviour
{
    private Animator animator;
    public GameObject door_c;

    public GameObject interactText;
    public bool canInteract = false;

    public AudioSource interactSound;

    private void Awake()
    {
        animator = door_c.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(true);
            canInteract = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(false);
            canInteract = false;
        }
    }

    private void Update()
    {
        if(canInteract && Input.GetKeyDown(KeyCode.E))
        {
            interactText.SetActive(false);
            animator.SetTrigger("Open");
            interactSound.Play();
            canInteract = false;
            Destroy(gameObject);
        }
    }
}
