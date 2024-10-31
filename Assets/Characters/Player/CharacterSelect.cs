/*using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{

    
    public void StartGame(int selectedCharacterIndex)
    {
        // Save the selected character index to PlayerPrefs
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacterIndex);
        PlayerPrefs.Save();
        
        // Load the Level Selection scene
        SceneManager.LoadScene("LevelScene");
    }
}


*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
   public GameObject[] skins;
   public int selectedCharacter = 0;

   private void Awake()
   {
    selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
    foreach (GameObject player in skins)
    {
        player.SetActive(false);

        skins[selectedCharacter].SetActive(true);
    }
   }

   public void ChangeNext()
   {
    skins[selectedCharacter].SetActive(false);
    selectedCharacter = (selectedCharacter + 1) % skins.Length;
    skins[selectedCharacter].SetActive(true);
   }

   public void ChangePrev()
   {
    skins[selectedCharacter].SetActive(false);
    selectedCharacter--;
    if(selectedCharacter < 0)
    {
        selectedCharacter += skins.Length;
    }

    skins[selectedCharacter].SetActive(true);
   }

    public void StartGame()
    {
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}

