using System.Collections;
using System.Collections.Generic;
using Hertzole.GoldPlayer;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class PulleyTracker : MonoBehaviour
{
    public GameObject chain1;
    public GameObject chain2;
    public GameObject light;

    private Animator animator;
    private Animator chain2anim;
    private Animator lightAnim;

    public GameObject interactText;
    public GameObject noKeyText;

    public GameObject keyIn;
    public GameObject plate;

    public GameObject blockedDoor;

    private bool canInteract = false;
    public bool hasKey = false;

    public AudioSource chainPulley;

    private PlayerInventory playerInventory;


    private void Awake()
    {
        animator = chain1.GetComponent<Animator>();
        chain2anim = chain2.GetComponent<Animator>();
        lightAnim = light.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(true);
            playerInventory = other.GetComponent<PlayerInventory>();
            canInteract = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(false);
            noKeyText.SetActive(false);
            canInteract = false;
            //Debug.Log("out");
        }
    }

    private void Update()
    {
        if (canInteract && (Input.GetKeyDown(KeyCode.E)) && playerInventory.hasKey)
        {
            keyIn.SetActive(true);
            plate.SetActive(true);
            interactText.SetActive(false);
            noKeyText.SetActive(false);
            blockedDoor.SetActive(true);
            animator.SetTrigger("Pull");
            chain2anim.SetTrigger("Pull");
            lightAnim.SetTrigger("Open");
            chainPulley.Play();
            Destroy(gameObject);
        }

        if (canInteract && (Input.GetKeyDown(KeyCode.E)) && !playerInventory.hasKey)
        {
            interactText.SetActive(false);
            noKeyText.SetActive(true);
        }

    }
}
