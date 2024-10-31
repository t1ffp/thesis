using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour
{
    public Camera playerCamera;
    public Camera targetCamera;
    public Transform targetObject;
    public float moveSpeed = 2.0f;
    public MonoBehaviour playerController;
    public float transitionDuration = 1.0f;
    public Image fadeImage;
    private bool isMoving = false;
    private bool isTargetCameraActive = false;

    public GameObject heySprite;
    public GameObject interactText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(true);
            heySprite.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && !isMoving)
        {
            //Debug.Log("Pressed");

            interactText.SetActive(false);

            if (playerController != null)
            {
                playerController.enabled = false;
            }

            StartCoroutine(SwitchCameras());
        }
    }


    private IEnumerator SwitchCameras()
    {
        isMoving = true;

        yield return StartCoroutine(FadeTo(1.0f, transitionDuration));

        playerCamera.gameObject.SetActive(false);
        targetCamera.gameObject.SetActive(true);
        isTargetCameraActive = true;

        Vector3 originalPosition = targetCamera.transform.position;
        Vector3 targetPosition = targetObject.position;
        float journeyLength = Vector3.Distance(originalPosition, targetPosition);


        if (journeyLength > 0)
        {
            float startTime = Time.time;

            while (Time.time - startTime < transitionDuration)
            {
                float distCovered = (Time.time - startTime) * (moveSpeed / journeyLength);
                float fractionOfJourney = Mathf.Clamp01(distCovered);
                targetCamera.transform.position = Vector3.Lerp(originalPosition, targetPosition, fractionOfJourney);
                yield return null;
            }
        }

        targetCamera.transform.position = targetPosition;

        yield return StartCoroutine(FadeTo(0.0f, transitionDuration));

        isMoving = false;
    }

    private void Update()
    {

        if (isTargetCameraActive && Input.GetKeyDown(KeyCode.E))
        {
            ReturnToPlayerCamera();
        }
    }

    private void ReturnToPlayerCamera()
    {
        StartCoroutine(ReturnToPlayerCameraCoroutine());
    }

    private IEnumerator ReturnToPlayerCameraCoroutine()
    {
        isMoving = true;

        yield return StartCoroutine(FadeTo(1.0f, transitionDuration));

        targetCamera.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(true);
        isTargetCameraActive = false;

        yield return StartCoroutine(FadeTo(0.0f, transitionDuration));

        isMoving = false;

        if (playerController != null)
        {
            playerController.enabled = true;
        }
    }

    private IEnumerator FadeTo(float targetAlpha, float duration)
    {
        float startAlpha = fadeImage.color.a;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            Color color = fadeImage.color;
            color.a = alpha;
            fadeImage.color = color;
            yield return null;
        }

        Color finalColor = fadeImage.color;
        finalColor.a = targetAlpha;
        fadeImage.color = finalColor;
    }
}
