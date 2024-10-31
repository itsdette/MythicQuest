using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
   private void Start()
    {
        RestorePlayerPosition(); // Call the method to restore the player's position
    }

    private void RestorePlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Retrieve the saved position from PlayerPrefs
            float posX = PlayerPrefs.GetFloat("PlayerPosX", player.transform.position.x); // Default to current position
            float posY = PlayerPrefs.GetFloat("PlayerPosY", player.transform.position.y);
            float posZ = PlayerPrefs.GetFloat("PlayerPosZ", player.transform.position.z);
            
            // Set the player's position
            player.transform.position = new Vector3(posX, posY, posZ);
            Debug.Log($"Player position restored: {player.transform.position}"); // Debug log
        }
        else
        {
            Debug.LogWarning("Player not found during position restoration!"); // Debug warning if player is not found
        }
    }
}

