using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{
    public string creatureName; // To hold the creature's name or identifier
    public GameObject player; // Reference to the player GameObject
    public GameObject creature; // Reference to the creature GameObject

    // Call this method when transitioning to the fight scene
    public void StartFight()
    {
        // Optionally, save creature info in a static variable or PlayerPrefs
        PlayerPrefs.SetString("CreatureName", creatureName);
        
        // Load the FightBG scene
        SceneManager.LoadScene("FightingBGScene");
    }
}
