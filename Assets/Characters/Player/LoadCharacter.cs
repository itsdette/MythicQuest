/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;  // Array of character prefabs
    public Transform spawnPoint;           // Where the character will be instantiated

void Start()
{
    int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
    Debug.Log("Selected character index: " + selectedCharacter);
    Debug.Log("Number of character prefabs: " + characterPrefabs.Length);

    // Check if the selected character index is within bounds
    if (selectedCharacter < 0 || selectedCharacter >= characterPrefabs.Length)
    {
        Debug.LogError("Selected character index is out of bounds! Resetting to 0.");
        selectedCharacter = 0; // or set a default value
    }

    GameObject prefab = characterPrefabs[selectedCharacter];
    Instantiate(prefab, spawnPoint.position, Quaternion.identity);
}

}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public CinemachineVirtualCamera VirtualCamera; // Reference to your virtual camera
    public string playerSortingLayer = "Player"; // Set the correct sorting layer name here
    public int playerSortingOrder = 0;


    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        clone.tag = "Player";

        // Set the virtual camera to follow the instantiated player
        VirtualCamera.Follow = clone.transform;
        
        SpriteRenderer playerRenderer = clone.GetComponent<SpriteRenderer>();
        if (playerRenderer != null)
        {
            playerRenderer.sortingLayerName = playerSortingLayer;
            playerRenderer.sortingOrder = playerSortingOrder;
        }

    }
}
