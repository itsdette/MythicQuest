using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionScript : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        // Load the selected level (Luzon, Visayas, or Mindanao)
        SceneManager.LoadScene(levelName);
    }
}

/*
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionScript : MonoBehaviour
{
    public void LoadLuzonScene()
    {
        // Set CurrentMap to identify Luzon
        PlayerPrefs.SetString("CurrentMap", "LuzonScene 1");
        SceneManager.LoadScene("LuzonScene 1");
    }

    public void LoadVisayasScene()
    {
        // Set CurrentMap to identify Visayas
        PlayerPrefs.SetString("CurrentMap", "VisayasScene");
        SceneManager.LoadScene("VisayasScene");
    }

    public void LoadMindanaoScene()
    {
        // Set CurrentMap to identify Mindanao
        PlayerPrefs.SetString("CurrentMap", "MindanaoScene");
        SceneManager.LoadScene("MindanaoScene");
    }
}
*/