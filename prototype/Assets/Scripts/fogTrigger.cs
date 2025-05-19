using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogTrigger : MonoBehaviour
{
    public float newFogDensity = 0.05f;
    public bool smoothTransition = true;
    public float transitionDuration = 2f;

    public AudioSource factoryAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (smoothTransition)
                StartCoroutine(ChangeFogDensitySmoothly(RenderSettings.fogDensity, newFogDensity, transitionDuration));
            else
                RenderSettings.fogDensity = newFogDensity;

            factoryAudio.Play();

        }
    }

    private IEnumerator ChangeFogDensitySmoothly(float start, float end, float duration)
    {
        float startVolume = factoryAudio.volume;
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            RenderSettings.fogDensity = Mathf.Lerp(start, end, t / duration);
            factoryAudio.volume = Mathf.Lerp(startVolume, 0.8f, t / duration);
            yield return null;
        }

        RenderSettings.fogDensity = end;
        Destroy(gameObject);
    }
}
