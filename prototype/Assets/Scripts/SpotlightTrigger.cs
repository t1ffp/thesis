using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SpotlightTrigger : MonoBehaviour
{
    public bool playerInTrigger = false;
    public float damagePerSecond = 20f;

    public SpotlightDetect2 detectScript;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;

            if (!detectScript.playerSpotted)
            {
                other.GetComponent<Player>()?.TakeDamage(damagePerSecond * Time.deltaTime);
                //Debug.Log("taking damage");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }
}
