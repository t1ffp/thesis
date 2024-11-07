using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{
    public AudioSource heartBeat;
    public AudioSource beeping;
    private Coroutine fadeCoroutine;
    public float fadeDuration = 2f;

    public Animator towerAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !heartBeat.isPlaying && !beeping.isPlaying)
        {
            /*
            if (fadeCoroutine != null)
            {
                StopCoroutine(FadeOutAudio());
            }
            */

            towerAnim.speed = 0f;
            heartBeat.Play();
            beeping.Play();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            towerAnim.speed = 1f;
            //StartCoroutine(FadeOutAudio());

            heartBeat.Stop();
            beeping.Stop();
        }
    }

    /*
    private IEnumerator FadeOutAudio()
    {
        float startVolume = heartBeat.volume;
        float startVolume2 = beeping.volume;

        
        float time = 0f;
        while (time < fadeDuration)
        {
            heartBeat.volume = Mathf.Lerp(startVolume, 0f, time / fadeDuration);
            beeping.volume = Mathf.Lerp(startVolume2, 0f, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }

        heartBeat.volume = 0f;
        heartBeat.Stop();

        beeping.volume = 0f;
        beeping.Stop();
    }
    */
}
