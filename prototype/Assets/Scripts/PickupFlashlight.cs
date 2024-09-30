using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlashlight : MonoBehaviour
{
    public GameObject pickUpText;
    public GameObject FLOnPlayer;

    void Start()
    {
        pickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                gameObject.SetActive(false);
                FLOnPlayer.SetActive(true);
                pickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.SetActive(false);
        }
    }
}
