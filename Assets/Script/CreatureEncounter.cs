/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this line

public class CreatureEncounter : MonoBehaviour
{
    public void EncounterCreature(int creatureIndex)
    {
        // Save the encountered creature's index
        PlayerPrefs.SetInt("EncounteredCreature", creatureIndex);
        PlayerPrefs.Save();

        // Load the fight scene
        SceneManager.LoadScene("FightingBGScene");
    }
}
*/
/*
//CORRECT CODE

using UnityEngine;
using UnityEngine.SceneManagement; // Add this line


public class CreatureEncounter : MonoBehaviour
{
    private bool playerInRange = false;
    private int encounteredCreatureIndex;

 /*   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CreatureIndex creature = GetComponent<CreatureIndex>();  // Get the creature's index

            if (creature != null)
            {
                // Store the encountered creature's index for later use
                encounteredCreatureIndex = creature.creatureIndex;
                playerInRange = true;  // Player is in range

                // Debug log for the index of the creature encountered
                Debug.Log("Player entered creature trigger. Encountered Creature Index Set: " + encounteredCreatureIndex);
            }
        }
    }

    // In your creature encounter script
private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        // Set the current region based on the scene
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("CurrentRegion", currentScene); // Save the current scene name
        PlayerPrefs.Save();

        Debug.Log("CurrentRegion set to: " + currentScene); // Debug log

        // Load the interaction scene
        SceneManager.LoadScene("InteractionScene");
    }
}


    public void OnFightButtonClicked()
    {
        if (playerInRange)
        {
            Debug.Log("Fight button pressed. Player is in range of the creature.");

            // Save the encountered creature's index to PlayerPrefs
            PlayerPrefs.SetInt("EncounteredCreature", encounteredCreatureIndex);
            PlayerPrefs.Save();  // Force the save to happen

            Debug.Log("Saved Encountered Creature Index to PlayerPrefs: " + encounteredCreatureIndex);

            // Load the fight scene
            UnityEngine.SceneManagement.SceneManager.LoadScene("FightingBGScene");
        }
        else
        {
            Debug.LogWarning("Player is not in range of the creature!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;  // Reset the range when the player leaves
            Debug.Log("Player exited creature trigger.");
        }
    }
}
*/ //CORRECT
/*
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatureEncounter : MonoBehaviour
{
    private bool playerInRange = false;
    private int encounteredCreatureIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CreatureIndex creature = GetComponent<CreatureIndex>();

            if (creature != null)
            {
                encounteredCreatureIndex = creature.creatureIndex;
                playerInRange = true;

                // Save the creature index to PlayerPrefs
                PlayerPrefs.SetInt("EncounteredCreature", encounteredCreatureIndex);
                PlayerPrefs.Save();
            }
        }
    }

    public void OnFightButtonClicked()
    {
        if (playerInRange)
        {
            // Check the current map and set the appropriate fighting scene
            string currentMap = PlayerPrefs.GetString("CurrentMap", "LuzonScene 1");
            string fightSceneToLoad;

            switch (currentMap)
            {
                case "LuzonScene 1":
                    fightSceneToLoad = "FightingBGScene1";
                    break;
                case "VisayasScene":
                    fightSceneToLoad = "FightingBGScene2";
                    break;
                case "MindanaoScene":
                    fightSceneToLoad = "FightingBGScene";
                    break;
                default:
                    fightSceneToLoad = "FightingBGScene"; // Default scene if unknown map
                    break;
            }

            // Store the selected fighting scene name and load it
            PlayerPrefs.SetString("FightSceneToLoad", fightSceneToLoad);
            SceneManager.LoadScene(fightSceneToLoad);
        }
        else
        {
            Debug.LogWarning("Player is not in range of the creature!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
*/
//CORRECT
/*
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatureEncounter : MonoBehaviour
{
    private bool playerInRange = false;
    private int encounteredCreatureIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Set the current region based on the active scene
            string currentScene = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("CurrentRegion", currentScene); // Save the current scene name
            PlayerPrefs.Save();

            Debug.Log("CurrentRegion set to: " + currentScene); // Debug log

            // Load the interaction scene
            SceneManager.LoadScene("InteractionScene");
        }
    }

    public void OnFightButtonClicked()
    {
        if (playerInRange)
        {
            Debug.Log("Fight button pressed. Player is in range of the creature.");

            // Save the encountered creature's index to PlayerPrefs
            PlayerPrefs.SetInt("EncounteredCreature", encounteredCreatureIndex);
            PlayerPrefs.Save(); // Force the save to happen

            Debug.Log("Saved Encountered Creature Index to PlayerPrefs: " + encounteredCreatureIndex);

            // Load the fight scene
            SceneManager.LoadScene("FightingBGScene");
        }
        else
        {
            Debug.LogWarning("Player is not in range of the creature!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; // Reset the range when the player leaves
            Debug.Log("Player exited creature trigger.");
        }
    }
}
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatureEncounter : MonoBehaviour
{
    private bool playerInRange = false;
    private int encounteredCreatureIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the current active scene's name
            string currentScene = SceneManager.GetActiveScene().name;

            // Save the current scene name to PlayerPrefs
            PlayerPrefs.SetString("CurrentRegion", currentScene);
            PlayerPrefs.Save();

            Debug.Log("OnTriggerEnter2D - CurrentRegion saved as: " + currentScene);

            // Get the creature's index if it exists
            CreatureIndex creature = GetComponent<CreatureIndex>();
            if (creature != null)
            {
                encounteredCreatureIndex = creature.creatureIndex;
                playerInRange = true; // Player is in range of the creature
                Debug.Log("Encountered Creature Index set to: " + encounteredCreatureIndex);
            }

            // Load the interaction scene
            SceneManager.LoadScene("InteractionScene");
        }
    }

    public void OnFightButtonClicked()
    {
        Debug.Log("OnFightButtonClicked - Called");

        if (playerInRange)
        {
            Debug.Log("Fight button pressed. Player is in range of the creature.");

            // Save the encountered creature's index to PlayerPrefs
            PlayerPrefs.SetInt("EncounteredCreature", encounteredCreatureIndex);
            PlayerPrefs.Save();

            Debug.Log("Encountered Creature Index saved as: " + encounteredCreatureIndex);

            // Retrieve the current region from PlayerPrefs
            string currentRegion = PlayerPrefs.GetString("CurrentRegion", "Unknown");

            Debug.Log("OnFightButtonClicked - CurrentRegion retrieved as: " + currentRegion);

            // Load the appropriate FightingBGScene based on the current region
            if (currentRegion == "LuzonScene1")
            {
                SceneManager.LoadScene("FightingBGScene1"); // Load Luzon fight scene
                Debug.Log("Loading FightingBGScene1 for Luzon.");
            }
            else if (currentRegion == "VisayasScene")
            {
                SceneManager.LoadScene("FightingBGScene2"); // Load Visayas fight scene
                Debug.Log("Loading FightingBGScene2 for Visayas.");
            }
            else if (currentRegion == "MindanaoScene")
            {
                SceneManager.LoadScene("FightingBGScene"); // Load Mindanao fight scene
                Debug.Log("Loading FightingBGScene for Mindanao.");
            }
            else
            {
                Debug.LogWarning("CurrentRegion not recognized, defaulting to FightingBGScene (Mindanao).");
                SceneManager.LoadScene("FightingBGScene"); // Default to Mindanao scene as a fallback
            }
        }
        else
        {
            Debug.LogWarning("OnFightButtonClicked - Player is not in range of the creature!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; // Reset the range when the player leaves
            Debug.Log("Player exited creature trigger.");
        }
    }
}
