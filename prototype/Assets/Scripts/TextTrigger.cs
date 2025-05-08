using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public GameObject interactText;
    private bool isTyping = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTyping)
        {
            StartCoroutine(ShowText());
        }
    }

    private IEnumerator ShowText()
    {
        isTyping = true;
        yield return new WaitForSeconds(1.5f);
        interactText.SetActive(true);
        Destroy(gameObject);
    }

}
