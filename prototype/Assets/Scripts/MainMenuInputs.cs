using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuInputs : MonoBehaviour
{
    //private bool canClick = false;

    public Image flashImage; 
    public float flashDuration = 1.5f;

    private bool isTransitioning = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isTransitioning) return;

        if (other.CompareTag("Start") && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LoadScene());
        }
        if (other.CompareTag("Exit") && Input.GetMouseButtonDown(0))
        {
            //Debug.Log("exit");
            Application.Quit();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isTransitioning) return;

        if (other.CompareTag("Start") && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LoadScene());
        }
        if (other.CompareTag("Exit") && Input.GetMouseButtonDown(0))
        {
            //Debug.Log("exit");
            Application.Quit();
        }
    }

    IEnumerator LoadScene()
    {
        isTransitioning = true;

        float elapsed = 0f;
        Color color = flashImage.color;

        while (elapsed < flashDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / flashDuration);
            flashImage.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        yield return new WaitForSeconds(0.3f);

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    /**

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && canClick)
            {
                //Debug.Log("hit");
                int currentIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentIndex + 1);
            }

        }
    **/

}
