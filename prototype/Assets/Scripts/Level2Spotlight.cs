using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Spotlight : MonoBehaviour
{
    public bool playerInTrigger = false;
    public float damagePerSecond = 20f;

    public AudioSource heartBeat;
    public AudioSource beeping;

    public Animator animator;
    private bool audioCD;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
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
            //playerInTrigger = true;
            other.GetComponent<Player>()?.TakeDamage(damagePerSecond * Time.deltaTime);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }

    private void Update()
    {
        if (playerInTrigger)
        {
            animator.enabled = false;
            if (!heartBeat.isPlaying && !beeping.isPlaying && !audioCD)
            {
                heartBeat.Play();
                beeping.Play();

                StartCoroutine(AudioCooldown(1f));

                //Debug.Log("playing");
            }
        }
        else
        {
            animator.enabled = true;
            //heartBeat.Stop();
            //beeping.Stop();
        }

    }
    
    IEnumerator AudioCooldown(float delay)
    {
        audioCD = true;
        yield return new WaitForSeconds(delay);

        yield return StartCoroutine(FadeAudio(heartBeat, 1f));
        yield return StartCoroutine(FadeAudio(beeping, 1f));

        audioCD = false;
        //heartBeat.Stop();
//beeping.Stop();
    }

    IEnumerator FadeAudio(AudioSource audioSource, float fadeDuration)
    {
        float startVol = audioSource.volume;

        while(audioSource.volume > 0f)
        {
            audioSource.volume -= startVol * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVol;
    }

}
