using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Hertzole.GoldPlayer;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Level2Trigger : MonoBehaviour
{
    public GameObject interactTxt;
    private bool isLooking = false;

    public Transform teleportLocation;
    public Transform playerPos;


   private void OnTriggerStay(Collider other)
   {
       if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
       {
           interactTxt.SetActive(true);
           other.GetComponent<CharacterController>().enabled = false;
           playerPos.position = teleportLocation.position;
           other.GetComponent<CharacterController>().enabled = true;
        }

   }

  

    /**
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("MainCamera"))
            {
                interactTxt.SetActive(true);
                isLooking = true;
            }
            else
            {
                //interactTxt.SetActive(false);
                //isLooking = false;
            }
        }

      

        private void Update()
        {
            if (isLooking && Input.GetKeyDown(KeyCode.E))
            {
                playerPos.position = teleportLocation.position;
            }
        }
    **/
}
