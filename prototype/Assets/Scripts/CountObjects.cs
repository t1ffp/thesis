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

    public GameObject endText;

    private void Start()
    {
        water.SetActive(false);
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
            endText.SetActive(true);
        }
    }
}
