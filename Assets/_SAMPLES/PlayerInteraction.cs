using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject dialogBox; // The UI dialog box
    private CreatureData currentCreatureData;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Creature"))
        {
            currentCreatureData = other.GetComponent<Creature>().creatureData;
            dialogBox.SetActive(true); // Show dialog box
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Creature"))
        {
            dialogBox.SetActive(false); // Hide dialog box
            currentCreatureData = null;
        }
    }

    public void OnInteractButtonPressed()
    {
        if (currentCreatureData != null)
        {
            // Store creature data before switching scenes
            CreatureDetailsHolder.creatureToDisplay = currentCreatureData;
            UnityEngine.SceneManagement.SceneManager.LoadScene("CreatureDetailScene");
        }
    }
}
