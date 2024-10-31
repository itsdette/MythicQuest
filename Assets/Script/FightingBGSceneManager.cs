using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightingBGSceneManager : MonoBehaviour
{
    public Image npcImage; // Assign this in the Inspector for displaying the creature
    public TMP_Text npcNameText; // Assign this in the Inspector for the NPC name
    public GameObject player; // Assign this in the Inspector, player prefab to be displayed
    public GameObject npc; // Assign this in the Inspector, NPC prefab to be displayed

    private void Start()
    {
        // Retrieve the NPC data from PlayerPrefs
        string npcName = PlayerPrefs.GetString("NPCName");
        string npcImageName = PlayerPrefs.GetString("NPCImage");

        // Load the NPC image from Resources or the appropriate location
        Sprite npcSprite = Resources.Load<Sprite>(npcImageName);

        // Check if the sprite was loaded successfully and set it
        if (npcSprite != null && npcImage != null)
        {
            npcImage.sprite = npcSprite;
        }

        // Set the NPC name
        if (npcNameText != null)
        {
            npcNameText.text = npcName;
        }

        // Display player and NPC models in the fight scene
        if (player != null)
        {
            // Set player position or animations, etc.
            player.SetActive(true); // Ensure player is visible
        }

        if (npc != null)
        {
            // Set NPC position or animations, etc.
            npc.SetActive(true); // Ensure NPC is visible
        }
    }

    private void OnDestroy()
    {
        // Clear PlayerPrefs for next time
        PlayerPrefs.DeleteKey("NPCName");
        PlayerPrefs.DeleteKey("NPCImage");
    }
}
