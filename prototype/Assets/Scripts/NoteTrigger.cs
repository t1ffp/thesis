using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTrigger : MonoBehaviour
{
    public GameObject interactText;
    public GameObject noteText;
    private bool canInteract = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            interactText.SetActive(false);
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            interactText.SetActive(false);
            noteText.SetActive(true);
            StartCoroutine(DeactivateObjects(6f));
        }

    }

    IEnumerator DeactivateObjects(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        noteText.SetActive(false);
    }
}
