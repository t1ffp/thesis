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

    public Transform playerCamera;


   private void OnTriggerStay(Collider other)
   {

       if (other.CompareTag("Player"))
       {
            Ray ray = new Ray(playerCamera.position, playerCamera.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, 50f))
            {
                interactTxt.SetActive(true);
                isLooking = true;
            }
            else
            {
                interactTxt.SetActive(false);
                //isLooking = false;
            }
            if (Input.GetKeyDown(KeyCode.E) && isLooking)
            {
                other.GetComponent<CharacterController>().enabled = false;
                playerPos.position = teleportLocation.position;
                other.GetComponent<CharacterController>().enabled = true;
                interactTxt.SetActive(false);
            }
        }
   }

    private void OnTriggerExit(Collider other)
    {
        interactTxt.SetActive(false);
        isLooking = false;
    }

}
