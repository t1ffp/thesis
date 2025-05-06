using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject interactText;
    public GameObject pickedUpText;
    private bool canInteract;

    public GameObject playerInv;

    public GameObject interaction;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(true);
            canInteract = true;

            /**
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.hasKey = true;
                Destroy(gameObject);
            }
            **/
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
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            PlayerInventory inventory = playerInv.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.hasKey = true;
                Destroy(gameObject);
            }
            interactText.SetActive(false);
            pickedUpText.SetActive(true);
            interaction.SetActive(true);
            canInteract = false;
        }
    }

}
