using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public GameObject gate1;
    public GameObject gate2;

    public GameObject openText;
    public GameObject lockedText;

    public KeyPickup keyPickup;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            openText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                if(keyPickup.canOpen == true)
                {
                    gate1.SetActive(false);
                    gate2.SetActive(false);
                    openText.SetActive(false);
                }
                else
                {
                    openText.SetActive(false);
                    lockedText.SetActive(true);
                }
              
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            openText.SetActive(false);
            lockedText.SetActive(false);
        }
    }
}
