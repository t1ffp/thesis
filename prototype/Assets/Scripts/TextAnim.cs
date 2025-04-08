using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextAnim : MonoBehaviour
{
    public Animator animator;
    //private bool canClick = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Light"))
        {
            //Debug.Log("entered");
            animator.SetBool("Play", true);
            //canClick = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Light"))
        {
            animator.SetBool("Play", true);
            //canClick = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Light"))
        {
            //Debug.Log("entered");
            animator.SetBool("Play", false);
            //canClick = false;
        }
    }

/**
    private void OnMouseDown()
    {
        if (canClick)
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);
        }
    }
**/

}
