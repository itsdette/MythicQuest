using UnityEngine;
using Cinemachine;

public class LoadFightSceneCharacters : MonoBehaviour
{
    public GameObject[] playerPrefabs;  // List of player character prefabs
    public GameObject[] creaturePrefabs;  // List of creature prefabs
    public Transform playerSpawnPoint;  // Spawn point for the player
    public Transform creatureSpawnPoint;  // Spawn point for the creature
    public CinemachineVirtualCamera virtualCamera; // Reference to your virtual camera

    // Sorting layer and order for player and creature
    public string playerSortingLayer = "Player";
    public int playerSortingOrder = 0;
    public string creatureSortingLayer = "Creature";
    public int creatureSortingOrder = 0;

    void Start()
    {
        // Ensure prefabs are assigned
        if (playerPrefabs == null || playerPrefabs.Length == 0)
        {
            Debug.LogError("Player prefabs are not assigned or empty!");
            return;
        }
        if (creaturePrefabs == null || creaturePrefabs.Length == 0)
        {
            Debug.LogError("Creature prefabs are not assigned or empty!");
            return;
        }

        LoadPlayerCharacter();
        LoadEncounteredCreature();
    }

    void LoadPlayerCharacter()
    {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);  // Default to the first character
        if (selectedCharacter < 0 || selectedCharacter >= playerPrefabs.Length)
        {
            Debug.LogError("Selected player character index is out of range: " + selectedCharacter);
            return;  // Early exit if index is invalid
        }

        GameObject playerPrefab = playerPrefabs[selectedCharacter];
        if (playerPrefab != null)
        {
            GameObject playerClone = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
            playerClone.tag = "Player";

            // Set the virtual camera to follow the instantiated player
            virtualCamera.Follow = playerClone.transform;

            // Set sorting layer for the player
            SpriteRenderer playerRenderer = playerClone.GetComponent<SpriteRenderer>();
            if (playerRenderer != null)
            {
                playerRenderer.sortingLayerName = playerSortingLayer;
                playerRenderer.sortingOrder = playerSortingOrder;
            }
        }
        else
        {
            Debug.LogError("Player prefab not found for index: " + selectedCharacter);
        }
    }

    void LoadEncounteredCreature()
    {
        // Retrieve the encountered creature's index from PlayerPrefs
        int encounteredCreature = PlayerPrefs.GetInt("EncounteredCreature", -1);  // Default to -1 if not set
        Debug.Log("Encountered Creature Index Loaded: " + encounteredCreature);

        // Validate encounteredCreature index
        if (encounteredCreature < 0 || encounteredCreature >= creaturePrefabs.Length)
        {
            Debug.LogError("Encountered creature index is out of bounds or invalid: " + encounteredCreature);
            return;  // Exit if index is invalid
        }

        GameObject creaturePrefab = creaturePrefabs[encounteredCreature];
        if (creaturePrefab != null)
        {
            GameObject creatureClone = Instantiate(creaturePrefab, creatureSpawnPoint.position, Quaternion.identity);

            // Set sorting layer for the creature
            SpriteRenderer creatureRenderer = creatureClone.GetComponent<SpriteRenderer>();
            if (creatureRenderer != null)
            {
                creatureRenderer.sortingLayerName = creatureSortingLayer;
                creatureRenderer.sortingOrder = creatureSortingOrder;
            }
        }
        else
        {
            Debug.LogError("Creature prefab not found for index: " + encounteredCreature);
        }
    }
}
