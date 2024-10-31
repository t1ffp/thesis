using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieTrigger : MonoBehaviour
{
    public GameObject blueGuy;
    public GameObject tieGuy;


    private void Start()
    {
        tieGuy.SetActive(false);
        blueGuy.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Pickable"))
        {
            blueGuy.SetActive(false);
            tieGuy.SetActive(true);
        }
    }
}
