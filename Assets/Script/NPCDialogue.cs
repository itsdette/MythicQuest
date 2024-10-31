/*using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCDialogue : MonoBehaviour
{
    public NPCData npcData; // Assign this in the Inspector
    private bool isPlayerInRange = false;
    public GameObject panel;
    public Button interactButton; // Assign this in the Inspector
    public Button attackButton; // Assign this in the Inspector
    //private string[] npcImageNames = { "Akop", "Alan", "Anduguno", "Ansisit", "Batibat", "Bingil", "Binobaan", "Boroka", "Calangit", "Camana", "Ebwa", "Enkantadya", "Hukluban", "Kulariu", "Lewenri" };

    private void Awake()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }

        if (interactButton != null)
        {
            interactButton.gameObject.SetActive(false);
            interactButton.onClick.AddListener(OnInteractButtonPressed);
        }

        if (attackButton != null)
        {
            attackButton.gameObject.SetActive(false);
            attackButton.onClick.AddListener(OnAttackButtonPressed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered NPC trigger.");
            isPlayerInRange = true;

            if (panel != null)
            {
                panel.SetActive(true); // Show the panel
            }
            interactButton?.gameObject.SetActive(true);
            attackButton?.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited NPC trigger.");
            isPlayerInRange = false;

            if (panel != null)
            {
                panel.SetActive(false); // Show the panel
            }
            if (interactButton != null && interactButton.gameObject.activeSelf)
            {
                interactButton.gameObject.SetActive(false);
            }

            if (attackButton != null && attackButton.gameObject.activeSelf)
            {
                attackButton.gameObject.SetActive(false);
            }
        }
    }

private void OnInteractButtonPressed()
{
    if (isPlayerInRange)
    {
        Debug.Log("Interact button pressed!");

        // Save the current region/scene name
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("CurrentRegion", currentScene);

        // Save the player's current position before changing the scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;
            PlayerPrefs.SetFloat("PlayerPosX", playerPosition.x);
            PlayerPrefs.SetFloat("PlayerPosY", playerPosition.y);
            PlayerPrefs.SetFloat("PlayerPosZ", playerPosition.z);

            Debug.Log($"Player position saved: {playerPosition}");
        }

        // Save NPC details to pass to the interaction scene
        PlayerPrefs.SetString("NPCName", npcData.npcName);
        PlayerPrefs.SetString("NPCDescription", npcData.npcDescription);
        PlayerPrefs.SetString("NPCImage", npcData.npcImage.name);

        // Load the interaction scene
        SceneManager.LoadScene(npcData.interactSceneName);
    }
}


/*


   private void OnInteractButtonPressed()
    {
        if (isPlayerInRange)
        {
            Debug.Log("Interact button pressed!");
            // Pass NPC data to the interaction scene
            PlayerPrefs.SetString("NPCName", npcData.npcName);
            PlayerPrefs.SetString("NPCDescription", npcData.npcDescription);

            if (npcData.npcImage != null)
            {
                // Store the path or name of the NPC image instead of picking a random one
                // Ideally, you can load your image from Resources or any other method
                PlayerPrefs.SetString("NPCImage", npcData.npcImage.name); // You should ensure the image is named properly in the Resources folder if loading from Resources.
            }
            else
            {
                Debug.LogWarning("No image set for this NPC in the NPCData object.");
            }

            SceneManager.LoadScene(npcData.interactSceneName);
        }
    }
*/
  /*  private void OnAttackButtonPressed()
    {
        if (isPlayerInRange)
        {
            Debug.Log("Attack button pressed!");
            SceneManager.LoadScene(npcData.fightSceneName);
        }
    }
    */
/*
    private void OnAttackButtonPressed()
{
    if (isPlayerInRange)
    {
        Debug.Log("Attack button pressed!");

        // Save the current region/scene name to return to after the fight (optional)
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("CurrentRegion", currentScene);

        // Save NPC details to pass to the fight scene
        PlayerPrefs.SetString("NPCName", npcData.npcName);
        PlayerPrefs.SetString("NPCImage", npcData.npcImage.name); // Image for display in the fight scene

        // Load the FightBGScene
        SceneManager.LoadScene("FightingBGScene");
    }
}

}*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCDialogue : MonoBehaviour
{
    public NPCData npcData; // Assign this in the Inspector
    private bool isPlayerInRange = false;
    public GameObject panel;
    public Button interactButton; // Assign this in the Inspector
    public Button attackButton; // Assign this in the Inspector

    private void Awake()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }

        if (interactButton != null)
        {
            interactButton.gameObject.SetActive(false);
            interactButton.onClick.AddListener(OnInteractButtonPressed);
        }

        if (attackButton != null)
        {
            attackButton.gameObject.SetActive(false);
            attackButton.onClick.AddListener(OnAttackButtonPressed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered NPC trigger.");
            isPlayerInRange = true;

            if (panel != null)
            {
                panel.SetActive(true); // Show the panel
            }
            interactButton?.gameObject.SetActive(true);
            attackButton?.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited NPC trigger.");
            isPlayerInRange = false;

            if (panel != null)
            {
                panel.SetActive(false); // Hide the panel
            }
            if (interactButton != null && interactButton.gameObject.activeSelf)
            {
                interactButton.gameObject.SetActive(false);
            }

            if (attackButton != null && attackButton.gameObject.activeSelf)
            {
                attackButton.gameObject.SetActive(false);
            }
        }
    }

    private void OnInteractButtonPressed()
    {
        if (isPlayerInRange)
        {
            Debug.Log("Interact button pressed!");

            // Save the current region/scene name
            string currentScene = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("CurrentRegion", currentScene);

            // Save the player's current position before changing the scene
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Vector3 playerPosition = player.transform.position;
                PlayerPrefs.SetFloat("PlayerPosX", playerPosition.x);
                PlayerPrefs.SetFloat("PlayerPosY", playerPosition.y);
                PlayerPrefs.SetFloat("PlayerPosZ", playerPosition.z);

                Debug.Log($"Player position saved: {playerPosition}");
            }

            // Save NPC details to pass to the interaction scene
            PlayerPrefs.SetString("NPCName", npcData.npcName);
            PlayerPrefs.SetString("NPCDescription", npcData.npcDescription);
            PlayerPrefs.SetString("NPCImage", npcData.npcImage.name);

            // Load the interaction scene
            SceneManager.LoadScene(npcData.interactSceneName);
        }
    }

    private void OnAttackButtonPressed()
    {
        if (isPlayerInRange)
        {
            Debug.Log("Attack button pressed!");

            // Save the current region/scene name
            string currentScene = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("CurrentRegion", currentScene);

            // Save player's selected character index for the fight scene
            int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

            // Save encountered creature's index to pass to the fight scene
            PlayerPrefs.SetInt("EncounteredCreature", npcData.creatureIndex);

            // Load the appropriate FightingBGScene based on the current region
            if (currentScene == "LuzonScene1")
            {
                Debug.Log("Loading FightingBGScene1 for Luzon.");
                SceneManager.LoadScene("FightingBGScene1");
            }
            else if (currentScene == "VisayasScene")
            {
                Debug.Log("Loading FightingBGScene2 for Visayas.");
                SceneManager.LoadScene("FightingBGScene2");
            }
            else if (currentScene == "MindanaoScene")
            {
                Debug.Log("Loading FightingBGScene for Mindanao.");
                SceneManager.LoadScene("FightingBGScene");
            }
            else
            {
                Debug.LogWarning("Current scene does not match any known region.");
            }
        }
    }
}
