using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    IEnumerator FadeIn()
    {
        float time = fadeDuration;
        while (time > 0)
        {
            time -= Time.deltaTime;
            SetAlpha(time / fadeDuration);
            yield return null;
        }
        SetAlpha(0);
    }

    IEnumerator FadeOutAndLoad(string sceneName)
    {
        float time = 0;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            SetAlpha(time / fadeDuration);
            yield return null;
        }
        SetAlpha(1);
        SceneManager.LoadScene(sceneName);
    }

    private void SetAlpha(float alpha)
    {
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = Mathf.Clamp01(alpha);
            fadeImage.color = c;
        }
    }
}
