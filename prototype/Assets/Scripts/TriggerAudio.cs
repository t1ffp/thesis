using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public AudioSource ominousAudio;
    public GameObject audioTrig;
    public GameObject enemyAI;

    private void Start()
    {
        audioTrig.SetActive(true);
        enemyAI.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        ominousAudio.Play();
        enemyAI.SetActive(true);
        audioTrig.SetActive(false);
    }

}
