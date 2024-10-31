using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        // Ensure there's only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartFight(int creatureIndex)
    {
        // Logic to start the fight based on the creature index
        Debug.Log($"Starting fight with creature index: {creatureIndex}");

        // Load the fight scene if needed
        SceneManager.LoadScene("FightingBGScene");
    }
}
