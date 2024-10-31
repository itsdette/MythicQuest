using System.Collections; // Required for IEnumerator
using UnityEngine;        // Required for MonoBehaviour and other Unity features

public class NarrationManager : MonoBehaviour
{
    public GameObject parallaxSet1;
    public GameObject parallaxSet2;
    public DialogueSystem dialogueSystem;  // Reference to the DialogueSystem

    private void Start()
    {
        parallaxSet1.SetActive(true);
        parallaxSet2.SetActive(false);
        StartNarration();
    }

    private void StartNarration()
    {
        dialogueSystem.StartDialogue();
        StartCoroutine(WaitForNarration());
    }

    private IEnumerator WaitForNarration()
    {
        // Wait until narration is active or completed
        while (dialogueSystem.isNarrationActive)  // Access the property correctly
        {
            yield return null;
        }

        SwitchToSecondParallaxSet();
    }

    private void SwitchToSecondParallaxSet()
    {
        parallaxSet1.SetActive(false);
        parallaxSet2.SetActive(true);
    }
}
