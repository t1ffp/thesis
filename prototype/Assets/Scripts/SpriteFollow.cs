using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpriteFollow : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float followSpeed = 2.0f; // Speed at which the sprite follows the player

    public float fadeDuration = 1.0f;
    public Image fadeImage;


    private void Start()
    {
    
        Color color = fadeImage.color;
        color.a = 0;
        fadeImage.color = color;
    }
    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            transform.position += direction * followSpeed * Time.deltaTime;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
            transform.rotation = targetRotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        Color color = fadeImage.color;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            color.a = Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1;
        fadeImage.color = color;

        SceneManager.LoadScene("Panopticon");
    }
}
