using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuInputs : MonoBehaviour
{
    //private bool canClick = false;

    public Image flashImage; 
    public float flashDuration = 1.5f;

    private bool isTransitioning = false;

    private bool start = false;
    private bool exit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isTransitioning) return;

        if (other.CompareTag("Start"))
        {
            start = true;
            exit = false;
            //StartCoroutine(LoadScene());
        }
        if (other.CompareTag("Exit"))
        {
            exit = true;
            start = false;
            //Debug.Log("exit");
            //Application.Quit();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isTransitioning) return;

        if (other.CompareTag("Start"))
        {
            start = false;
            //StartCoroutine(LoadScene());
        }
        if (other.CompareTag("Exit"))
        {
            exit = false;
            //Debug.Log("exit");
            //Application.Quit();
        }
    }

    /**
    private void OnTriggerStay(Collider other)
    {
        if (isTransitioning) return;

        if (other.CompareTag("Start"))
        {
            start = true;
            exit = false;
            //StartCoroutine(LoadScene());
        }
        if (other.CompareTag("Exit"))
        {
            exit = true;
            start = false;
            //Debug.Log("exit");
            Application.Quit();
        }
    }
    **/

    
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
        SceneManager.LoadScene("MainScene");
    }

    private void Update()
    {
        if (start && !exit && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LoadScene());
        }

        if(!start && exit && Input.GetMouseButtonDown(0))
        {
            Application.Quit();
        }

    }
}
