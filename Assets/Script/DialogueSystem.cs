using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText;  // UI element for dialogue text
    public Image characterPortraitImage;  // UI element for character portrait
    public string[] dialogueLines;  // Array of dialogue lines
    private int currentLineIndex = 0;

    // Property to indicate if narration is currently active
    public bool isNarrationActive { get; private set; }  // Make sure this property is here

    private void Start()
    {
        isNarrationActive = false;
    }

    public void StartDialogue()
    {
        isNarrationActive = true;
        ShowNextLine();
    }

    private void ShowNextLine()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    public void SkipToEnd()
    {
        // Skip to the last line of dialogue
        dialogueText.text = dialogueLines[dialogueLines.Length - 1];
        EndDialogue();
    }

    private void EndDialogue()
    {
        dialogueText.text = "";
        characterPortraitImage.sprite = null;
        isNarrationActive = false;  // Signal narration completion
        gameObject.SetActive(false);  // Optionally hide the dialogue system
    }
}
