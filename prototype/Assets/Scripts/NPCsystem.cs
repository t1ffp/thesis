using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCsystem : MonoBehaviour
{

    public bool player_detection = false;
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float dialogueSpeed;


    public Animator DialogueAnimator;
    private bool StartDialogue = true;

    private bool isTyping = false;
    private Coroutine typingCoroutine;


    // Update is called once per frame
    void Update()
    {

        if (player_detection && Input.GetKeyDown(KeyCode.E))
        {
            if (StartDialogue)
            {
                DialogueAnimator.SetTrigger("Enter");
                StartDialogue = false;

                NextSentence();
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
        //DialogueAnimator.SetTrigger("Exit");
    }

    void NextSentence()
    {
        if(Index <= Sentences.Length -1)
        {
            DialogueText.text = "";
            typingCoroutine = StartCoroutine(WriteSentence(Sentences[Index]));
        }
        else
        {
            DialogueText.text = "";
            DialogueAnimator.SetTrigger("Exit");
            Index = 0;
            StartDialogue = true;
            
        }
    }

    IEnumerator WriteSentence(string sentence)
    {

        isTyping = true;
        DialogueText.text = "";

        foreach (char Character in sentence.ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(dialogueSpeed);
        }

        isTyping = false;
        Index++;
    }
    
}
