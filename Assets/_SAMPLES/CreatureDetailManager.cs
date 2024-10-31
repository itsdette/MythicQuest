using UnityEngine;
using UnityEngine.UI;

public class CreatureDetailManager : MonoBehaviour
{
    public Text nameText;
    public Text descriptionText;
    public Image creatureImage;

    void Start()
    {
        if (CreatureDetailsHolder.creatureToDisplay != null)
        {
            nameText.text = CreatureDetailsHolder.creatureToDisplay.creatureName;
            descriptionText.text = CreatureDetailsHolder.creatureToDisplay.description;
            creatureImage.sprite = CreatureDetailsHolder.creatureToDisplay.creatureImage;
        }
    }

    public void OnBackButtonPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Luzon");
    }
}
