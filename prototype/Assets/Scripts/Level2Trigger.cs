using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Hertzole.GoldPlayer;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class Level2Trigger : MonoBehaviour
{
    public GameObject interactTxt;
    private bool isLooking = false;

    public Transform playerCamera;
    public AudioSource interactAudio;

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
                isLooking = false;
            }
        }
   }

    private void OnTriggerExit(Collider other)
    {
        interactTxt.SetActive(false);
        isLooking = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isLooking)
        {
            interactTxt.SetActive(false);
            interactAudio.Play();
            SceneManager.LoadScene("Panopticon");
        }
    }

}
