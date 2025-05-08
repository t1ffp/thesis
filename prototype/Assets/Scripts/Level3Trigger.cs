using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;


public class Level3Trigger : MonoBehaviour
{
    public string sceneToLoad;
    public ScreenFade sceneFader;

    public GameObject interactText;
    public AudioSource interactSound;

    private bool canInteract = false;

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            interactText.SetActive(false);
            interactSound.Play();
            sceneFader.FadeToScene(sceneToLoad);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(true);
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(false);
            canInteract = false;
        }
    }
}
