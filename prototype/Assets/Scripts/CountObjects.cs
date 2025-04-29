using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CountObjects : MonoBehaviour
{
    public string targetTag;
    private int objectCount = 0;

    public AudioClip waterSound;
    public AudioSource fountain;

    public GameObject water;

    public GameObject suitDialogue1;
    public GameObject suitDialogue2;
    public GameObject coinDialogue1;
    public GameObject coinDialogue2;

    public GameObject door;

    //public GameObject endText;

    private void Start()
    {
        water.SetActive(false);
        suitDialogue2.SetActive(false);
        coinDialogue2.SetActive(false);
        door.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            objectCount++;
            CheckObjectCount();
        }
    }   


    private void Update()
    {
        //CheckObjectCount();
    }

    private void CheckObjectCount()
    {
        if (objectCount == 2)
        {
           
            fountain.PlayOneShot(waterSound);
            water.SetActive(true);
            suitDialogue2.SetActive(true);
            suitDialogue1.SetActive(false);

            coinDialogue1.SetActive(false);
            coinDialogue2.SetActive(true);

            door.SetActive(false);
            //endText.SetActive(true);
        }
    }
}
