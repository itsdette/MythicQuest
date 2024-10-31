using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;         // UI Text element for the character's name
    public Text dialogueText;     // UI Text element for the dialogue

    public Animator animator;     // Optional: Animator for animating the dialogue panel

    private Queue<string> sentences;  // Queue to store the sentences

    void Start()
    {
        sentences = new Queue<string>();
    }

    // Start the dialogue with a specific character and sentences
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true); // Optional: Trigger an animation for showing the dialogue

        nameText.text = dialogue.characterName;
        sentences.Clear();

        // Add all sentences to the queue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    // Display the next sentence in the queue
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines(); // Stop any ongoing typewriting effect
        StartCoroutine(TypeSentence(sentence)); // Type out the sentence (optional)
    }

    // Typewriting effect for the dialogue text
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;  // Wait for a frame between each letter
        }
    }

    // End the dialogue
    void EndDialogue()
    {
        animator.SetBool("isOpen", false); // Optional: Trigger an animation for closing the dialogue
        Debug.Log("End of conversation.");
    }
}
