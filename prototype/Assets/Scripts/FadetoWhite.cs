using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadetoWhite : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    public AudioSource lightAudio;

    public void FadeToWhite()
    {
        StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeRoutine()
    {
        float startVolume = lightAudio.volume;

        float timer = 0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(1, 1, 1, 1);

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
            lightAudio.volume = Mathf.Lerp(startVolume, 0f, timer / fadeDuration);
            yield return null;
        }

        fadeImage.color = endColor;
        lightAudio.Stop();
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("EndScreen");
    }
}
