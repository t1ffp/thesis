using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public AudioSource ominousAudio;
    public GameObject audioTrig;
    public GameObject enemyAI;
    public GameObject enemyText;

    private void Start()
    {
        audioTrig.SetActive(true);
        enemyAI.SetActive(false);
        enemyText.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        ominousAudio.Play();
        enemyAI.SetActive(true);
        audioTrig.SetActive(false);
        enemyText.SetActive(true);
    }

}
