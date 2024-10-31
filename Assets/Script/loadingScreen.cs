using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class loadingScreen : MonoBehaviour
{
    public GameObject background;          // Reference to the loading screen background
    public Image loadingSliderFill;         // Reference to the fill area of the loading slider

    public void LoadScreen(int sceneIndex)
    {
        // Call a coroutine or some other logic here
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        // Show the loading screen
        background.SetActive(true);

        // Start loading the scene asynchronously
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false; // Optional: Prevent immediate scene activation

        // Update the loading slider while the scene is loading
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSliderFill.fillAmount = progress;

            // If the scene is almost loaded, allow scene activation
            if (operation.progress >= 0.9f)
            {
                // Optionally add a delay before allowing activation
                yield return new WaitForSeconds(1f);
                operation.allowSceneActivation = true;
            }

            yield return null; // Wait until the next frame
        }

        // Hide the loading screen
        background.SetActive(false);
    }
}
