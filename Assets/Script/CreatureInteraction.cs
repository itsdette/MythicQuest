using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatureInteraction : MonoBehaviour
{
    public GameObject dialogBox;  // Reference to the dialog box UI

    // ---------------------------------------------------------------------------------
    // Method to show the dialog box when the player is close to the creature
    public void ShowDialogBox()
    {
        dialogBox.SetActive(true);  // Enable the dialog box
    }

    // ---------------------------------------------------------------------------------
    // Method to handle the Fight button click
    public void OnFightButtonClicked()
    {
        // Load the FightBG scene for the battle
        SceneManager.LoadScene("FightBG");
    }

    // ---------------------------------------------------------------------------------
    // Method to handle the Interact button click
    public void OnInteractButtonClicked()
    {
        // Load the Interact scene to show creature details
        SceneManager.LoadScene("InteractScene");
    }

    // ---------------------------------------------------------------------------------
    // Method to close the dialog box (if needed)
    public void CloseDialogBox()
    {
        dialogBox.SetActive(false);  // Hide the dialog box
    }

    // ---------------------------------------------------------------------------------
    // Detect if the player is within the creature's interaction range
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Check if it's the player
        {
            ShowDialogBox();  // Show the dialog box when the player is close to the creature
        }
    }
}
