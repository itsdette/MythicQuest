/*using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InteractionSceneManager : MonoBehaviour
{
    public Image npcImage; // Assign this in the Inspector
    public TMP_Text npcDescriptionText; // Assign this in the Inspector
    public TMP_Text npcNameText; // Assign this in the Inspector
    public Button backButton; // Assign this in the Inspector

    public Button fightButton; // Assign this in the Inspector

    private void Start()
    {
        // Retrieve the NPC data from PlayerPrefs
        string npcName = PlayerPrefs.GetString("NPCName");
        string npcDescription = PlayerPrefs.GetString("NPCDescription"); 
        string npcImageName = PlayerPrefs.GetString("NPCImage");

        // Load the NPC image from Resources or the appropriate location
        Sprite npcSprite = Resources.Load<Sprite>(npcImageName);

        // Check if the sprite was loaded successfully
        if (npcSprite != null)
        {
            npcImage.sprite = npcSprite; // Set the NPC image
        }
        else
        {
            Debug.LogWarning($"NPC image '{npcImageName}' not found in Resources.");
        }

        // Set the NPC name and description
        npcNameText.text = npcName; // Set the NPC name
        npcDescriptionText.text = npcDescription; // Set the NPC description

        // Set up button listeners
        backButton.onClick.AddListener(OnBackButtonPressed);
        fightButton.onClick.AddListener(OnFightButtonPressed);
    }


private void OnBackButtonPressed()
{
    Debug.Log("Back to World button pressed!");

    // Retrieve the region the player was in before entering the interaction scene
    string previousRegion = PlayerPrefs.GetString("CurrentRegion", "LuzonScene 1"); // Default to Luzon if not set

    // Load the previous region
    SceneManager.LoadScene(previousRegion);
}


}

*/
 /*   private void OnBackButtonPressed()
    {
        Debug.Log("Back to World button pressed!");
        // Load the main game scene (replace with your main game scene name)
        SceneManager.LoadScene("LuzonScene 1");
    }
*/
  /*  private void OnFightButtonPressed()
    {
        Debug.Log("Fight button pressed!");
        // Load the FightBGScene
        SceneManager.LoadScene("FightingBGScene");
    }
*/ //CORRECT
/*
private void OnFightButtonPressed()
{
    Debug.Log("Fight button pressed!");

    // Save NPC details to pass to the fight scene
    PlayerPrefs.SetString("NPCName", PlayerPrefs.GetString("NPCName")); // Retrieve the existing NPC name
    PlayerPrefs.SetString("NPCImage", PlayerPrefs.GetString("NPCImage")); // Retrieve the existing NPC image

    // Load the FightBGScene
    SceneManager.LoadScene("FightingBGScene");
}

    private void OnDestroy()
    {
        // Clear PlayerPrefs to avoid stale data in future interactions
        PlayerPrefs.DeleteKey("NPCName");
        PlayerPrefs.DeleteKey("NPCDescription");
        PlayerPrefs.DeleteKey("NPCImage");
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class InteractionSceneManager : MonoBehaviour
{
    public Image characterImage;       // Assign in Inspector
    public Image creatureImage;        // Assign in Inspector
    public TMP_Text creatureNameText;  // Assign in Inspector
    public TMP_Text creatureDescriptionText; // Assign in Inspector

    private void Start()
    {
        // Load character image from selected character
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter", "DefaultCharacter");
        characterImage.sprite = Resources.Load<Sprite>(selectedCharacter);

        // Load the encountered creature index
        int encounteredCreatureIndex = PlayerPrefs.GetInt("EncounteredCreature", -1);

        if (encounteredCreatureIndex != -1)
        {
            // Load creature image and data based on index
            string creatureImageName = "Creature_" + encounteredCreatureIndex;
            creatureImage.sprite = Resources.Load<Sprite>(creatureImageName);

            // Set creature name and description (update these methods with actual logic)
            creatureNameText.text = GetCreatureName(encounteredCreatureIndex);
            creatureDescriptionText.text = GetCreatureDescription(encounteredCreatureIndex);
        }
        else
        {
            Debug.LogWarning("No creature data found for display.");
        }
    }

    private string GetCreatureName(int index)
    {
        // Placeholder logic - replace with actual creature name retrieval
        return "Creature Name " + index;
    }

    private string GetCreatureDescription(int index)
    {
        // Placeholder logic - replace with actual creature description retrieval
        return "Description for creature index " + index;
    }

    public void OnBackButtonPressed()
    {
        // Load the previous map based on saved data
        string previousMapScene = PlayerPrefs.GetString("CurrentMap", "LuzonScene 1");
        SceneManager.LoadScene(previousMapScene);
    }
}
*/
//CORRECT
/*
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InteractionSceneManager : MonoBehaviour
{
    public Image npcImage; // Assign this in the Inspector
    public TMP_Text npcDescriptionText; // Assign this in the Inspector
    public TMP_Text npcNameText; // Assign this in the Inspector
    public Button backButton; // Assign this in the Inspector
    public Button fightButton; // Assign this in the Inspector

    private void Start()
    {
        // Retrieve the NPC data from PlayerPrefs
        string npcName = PlayerPrefs.GetString("NPCName");
        string npcDescription = PlayerPrefs.GetString("NPCDescription");
        string npcImageName = PlayerPrefs.GetString("NPCImage");

        // Load the NPC image from Resources or the appropriate location
        Sprite npcSprite = Resources.Load<Sprite>(npcImageName);

        // Check if the sprite was loaded successfully
        if (npcSprite != null)
        {
            npcImage.sprite = npcSprite; // Set the NPC image
        }
        else
        {
            Debug.LogWarning($"NPC image '{npcImageName}' not found in Resources.");
        }

        // Set the NPC name and description
        npcNameText.text = npcName; // Set the NPC name
        npcDescriptionText.text = npcDescription; // Set the NPC description

        // Set up button listeners
        backButton.onClick.AddListener(OnBackButtonPressed);
        fightButton.onClick.AddListener(OnFightButtonPressed); // Ensure this method exists
    }

private void OnBackButtonPressed()
{
    Debug.Log("Back to World button pressed!");

    // Retrieve the region the player was in before entering the interaction scene
    string previousRegion = PlayerPrefs.GetString("CurrentRegion", "LuzonScene"); // Default to Luzon if not set
    Debug.Log("Previous Region: " + previousRegion);

    // Load the previous region
    SceneManager.LoadScene(previousRegion);
}

    private void OnFightButtonPressed() // Ensure this method is defined correctly
    {
        Debug.Log("Fight button pressed!");

        // Save NPC details to pass to the fight scene
        PlayerPrefs.SetString("NPCName", PlayerPrefs.GetString("NPCName")); // Retrieve the existing NPC name
        PlayerPrefs.SetString("NPCImage", PlayerPrefs.GetString("NPCImage")); // Retrieve the existing NPC image

        // Load the appropriate FightingBGScene based on the current region
        string currentRegion = PlayerPrefs.GetString("CurrentRegion");

        if (currentRegion == "LuzonScene 1")
        {
            SceneManager.LoadScene("FightingBGScene1");
        }
        else if (currentRegion == "VisayasScene")
        {
            SceneManager.LoadScene("FightingBGScene2");
        }
        else if (currentRegion == "MindanaoScene")
        {
            SceneManager.LoadScene("FightingBGScene");
        }
        else
        {
            Debug.LogWarning("Current region not recognized!");
        }
    }

    private void OnDestroy()
    {
        // Clear PlayerPrefs to avoid stale data in future interactions
        PlayerPrefs.DeleteKey("NPCName");
        PlayerPrefs.DeleteKey("NPCDescription");
        PlayerPrefs.DeleteKey("NPCImage");
    }
}
*/
//CORRECT
/*
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InteractionSceneManager : MonoBehaviour
{
    public Image npcImage; // Assign this in the Inspector
    public TMP_Text npcDescriptionText; // Assign this in the Inspector
    public TMP_Text npcNameText; // Assign this in the Inspector
    public Button backButton; // Assign this in the Inspector
    public Button fightButton; // Assign this in the Inspector

    private void Start()
    {
        // Retrieve the NPC data from PlayerPrefs
        string npcName = PlayerPrefs.GetString("NPCName");
        string npcDescription = PlayerPrefs.GetString("NPCDescription");
        string npcImageName = PlayerPrefs.GetString("NPCImage");

        // Load the NPC image from Resources or the appropriate location
        Sprite npcSprite = Resources.Load<Sprite>(npcImageName);

        // Check if the sprite was loaded successfully
        if (npcSprite != null)
        {
            npcImage.sprite = npcSprite; // Set the NPC image
        }
        else
        {
            Debug.LogWarning($"NPC image '{npcImageName}' not found in Resources.");
        }

        // Set the NPC name and description
        npcNameText.text = npcName; // Set the NPC name
        npcDescriptionText.text = npcDescription; // Set the NPC description

        // Set up button listeners
        backButton.onClick.AddListener(OnBackButtonPressed);
        fightButton.onClick.AddListener(OnFightButtonPressed);
    }

    private void OnBackButtonPressed()
    {
        Debug.Log("Back to World button pressed!");

        // Retrieve the region the player was in before entering the interaction scene
        string previousRegion = PlayerPrefs.GetString("CurrentRegion");

        // Check if previousRegion is not empty or null
        if (!string.IsNullOrEmpty(previousRegion))
        {
            Debug.Log("Previous Region: " + previousRegion);
            // Load the previous region
            SceneManager.LoadScene(previousRegion);
        }
        else
        {
            Debug.LogWarning("CurrentRegion not set! Defaulting to LuzonScene.");
            SceneManager.LoadScene("LuzonScene"); // Default if not set
        }
    }

    private void OnFightButtonPressed()
    {
        Debug.Log("Fight button pressed!");

        // Save NPC details to pass to the fight scene
        PlayerPrefs.SetString("NPCName", PlayerPrefs.GetString("NPCName")); // Retrieve the existing NPC name
        PlayerPrefs.SetString("NPCImage", PlayerPrefs.GetString("NPCImage")); // Retrieve the existing NPC image

        // Load the appropriate FightingBGScene based on the current region
        string currentRegion = PlayerPrefs.GetString("CurrentRegion");

        // Use a switch statement for clarity
        switch (currentRegion)
        {
            case "LuzonScene 1":
                SceneManager.LoadScene("FightingBGScene 1");
                break;
            case "VisayasScene":
                SceneManager.LoadScene("FightingBGScene 2");
                break;
            case "MindanaoScene":
                SceneManager.LoadScene("FightingBGScene");
                break;
            default:
                Debug.LogWarning("Current region not recognized! Defaulting to FightingBGScene.");
                SceneManager.LoadScene("FightingBGScene"); // Fallback
                break;
        }
    }

    private void OnDestroy()
    {
        // Clear PlayerPrefs to avoid stale data in future interactions
        PlayerPrefs.DeleteKey("NPCName");
        PlayerPrefs.DeleteKey("NPCDescription");
        PlayerPrefs.DeleteKey("NPCImage");
    }
}
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InteractionSceneManager : MonoBehaviour
{
    public Image npcImage; // Assign this in the Inspector
    public TMP_Text npcDescriptionText; // Assign this in the Inspector
    public TMP_Text npcNameText; // Assign this in the Inspector
    public Button backButton; // Assign this in the Inspector
    public Button fightButton; // Assign this in the Inspector

    private void Start()
    {
        // Retrieve the NPC data from PlayerPrefs
        string npcName = PlayerPrefs.GetString("NPCName");
        string npcDescription = PlayerPrefs.GetString("NPCDescription");
        string npcImageName = PlayerPrefs.GetString("NPCImage");

        // Load the NPC image from Resources or the appropriate location
        Sprite npcSprite = Resources.Load<Sprite>(npcImageName);

        // Check if the sprite was loaded successfully
        if (npcSprite != null)
        {
            npcImage.sprite = npcSprite; // Set the NPC image
        }
        else
        {
            Debug.LogWarning($"NPC image '{npcImageName}' not found in Resources.");
        }

        // Set the NPC name and description
        npcNameText.text = npcName; // Set the NPC name
        npcDescriptionText.text = npcDescription; // Set the NPC description

        // Set up button listeners
        backButton.onClick.AddListener(OnBackButtonPressed);
        fightButton.onClick.AddListener(OnFightButtonPressed); // Ensure this method exists
    }

private void OnBackButtonPressed()
{
    Debug.Log("Back to World button pressed!");

    // Retrieve the region the player was in before entering the interaction scene
    string previousRegion = PlayerPrefs.GetString("CurrentRegion", "LuzonScene"); // Default to Luzon if not set
    Debug.Log("Previous Region: " + previousRegion);

    // Load the previous region
    SceneManager.LoadScene(previousRegion);
}

    private void OnFightButtonPressed() // Ensure this method is defined correctly
    {
        Debug.Log("Fight button pressed!");

        // Save NPC details to pass to the fight scene
        PlayerPrefs.SetString("NPCName", PlayerPrefs.GetString("NPCName")); // Retrieve the existing NPC name
        PlayerPrefs.SetString("NPCImage", PlayerPrefs.GetString("NPCImage")); // Retrieve the existing NPC image

        // Load the appropriate FightingBGScene based on the current region
        string currentRegion = PlayerPrefs.GetString("CurrentRegion");

        if (currentRegion == "LuzonScene 1")
        {
            SceneManager.LoadScene("FightingBGScene1");
        }
        else if (currentRegion == "VisayasScene")
        {
            SceneManager.LoadScene("FightingBGScene2");
        }
        else if (currentRegion == "MindanaoScene")
        {
            SceneManager.LoadScene("FightingBGScene");
        }
        else
        {
            Debug.LogWarning("Current region not recognized!");
        }
    }

    private void OnDestroy()
    {
        // Clear PlayerPrefs to avoid stale data in future interactions
        PlayerPrefs.DeleteKey("NPCName");
        PlayerPrefs.DeleteKey("NPCDescription");
        PlayerPrefs.DeleteKey("NPCImage");
    }
}