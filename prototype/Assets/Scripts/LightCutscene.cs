using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCutscene : MonoBehaviour
{
    private Animator animator;
    //private Animator animator2;
    private Animator textAnim;
    private Animator cutscenetAnim;

    public GameObject item;
    //public GameObject item2;
    public GameObject textType;
    public GameObject lightCutscene;


    //public AudioSource interactSound;

    private void Awake()
    {
        animator = item.GetComponent<Animator>();
        //animator2 = item2.GetComponent<Animator>();
        textAnim = textType.GetComponent<Animator>();
        cutscenetAnim = lightCutscene.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().enabled = false;
            animator.SetTrigger("Stop");
            cutscenetAnim.SetTrigger("Stop");
            textAnim.SetTrigger("Fade");
            cutscenetAnim.SetTrigger("Start");
            //interactSound.Play();
            Destroy(gameObject);
        }

    }

}
