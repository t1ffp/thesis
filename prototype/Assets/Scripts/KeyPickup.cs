using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public bool canOpen = false;

    public GameObject key;

    public GameObject pickUpText;
    public GameObject keyText;

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                gameObject.SetActive(false);
                pickUpText.SetActive(false);
                //keyText.SetActive(true);
                canOpen = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.SetActive(false);
            keyText.SetActive(false);
        }
    }

 
}
