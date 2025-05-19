using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Hertzole.GoldPlayer;

public class NPCsystem : MonoBehaviour
{

    public bool player_detection = false;
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI interactText;
    public string[] Sentences;
    private int Index = 0;
    public float dialogueSpeed;


    public Animator DialogueAnimator;
    private bool startDialogue = true;

    private bool isTyping = false;
    private Coroutine typingCoroutine;

    public Transform playerCamera;
    public Transform npcTransform;

    public GameObject player;
    //private GoldPlayerInput playerInput;
    public MonoBehaviour playerInput;

    private bool canSkip = true;
    private float skipCooldown = 0.5f;


    private void Start()
    {
        interactText.gameObject.SetActive(false);
        //playerInput = player.GetComponent<GoldPlayerInput>();
    }
    void Update()
    {
        if (player_detection)
        {
            bool isLooking = LookAt();

            interactText.gameObject.SetActive(isLooking);

            if (isLooking && canSkip && Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                if (startDialogue)
                {
                    StartDialogue();
                }
                else
                {
                    if (isTyping)
                    {
                        StopCoroutine(typingCoroutine);
                        DialogueText.text = Sentences[Index];
                        isTyping = false;
                        Index++;
                    }
                    else
                    {
                        NextSentence();
                    }
                }
            }
        }
      
    }

    bool LookAt()
    {

        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == npcTransform)
            {
                return true;
            }
        }

        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_detection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player_detection = false;
        interactText.gameObject.SetActive(false);
    }

    void StartDialogue()
    {
        DialogueAnimator.SetTrigger("Enter");
        startDialogue = false;
        LockPlayer(true);
        Time.timeScale = 0f;
        NextSentence();
    }

    void EndDialogue()
    {
        DialogueText.text = "";
        DialogueAnimator.SetTrigger("Exit");
        Index = 0;
        startDialogue = true;
        LockPlayer(false);

        Time.timeScale = 1f;
    }

    void NextSentence()
    {
        if(Index <= Sentences.Length -1)
        {
            DialogueText.text = "";
            typingCoroutine = StartCoroutine(WriteSentence(Sentences[Index]));
            
            canSkip = false;
            Invoke(nameof(ResetSkip), skipCooldown);
        }
        else
        {
            EndDialogue();

        }
    }

    void ResetSkip()
    {
        canSkip = true;
    }

    IEnumerator WriteSentence(string sentence)
    {

        isTyping = true;
        DialogueText.text = "";

        foreach (char Character in sentence.ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSecondsRealtime(dialogueSpeed);
        }

        isTyping = false;
        Index++;
    }

    void LockPlayer(bool lockState)
    {
        if(playerInput != null)
        {
            playerInput.enabled = !lockState;
        }
    }
}
