using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    // No need for loading screen or progress bar references anymore
    // public GameObject loadingScreen;
    // public Slider progressBar;

    public void LuzonScene()
    {
        // Directly load the Luzon scene
        SceneManager.LoadScene(2);
    }

    public void VisayasScene()
    {
        // Directly load the Visayas scene
        SceneManager.LoadScene(3);
    }

        public void MindanaoScene()
    {
        // Directly load the Visayas scene
        SceneManager.LoadScene(4);
    }
}




//WITH LOADING SCREEN CODE

/*using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    public GameObject loadingScreen;  // Reference to the LoadingScreenUI (background and progress bar)
    public Slider progressBar;        // Reference to the Slider component

    public void LuzonScene()
    {
        // Start the coroutine to load the scene asynchronously
        StartCoroutine(LoadSceneAsync(2));
    }

    public void VisayasScene()
    {
        // Start the coroutine to load the scene asynchronously
        StartCoroutine(LoadSceneAsync(3));
    }

    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        // Show the loading screen UI
        loadingScreen.SetActive(true);

        // Start loading the scene asynchronously
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        // Update the progress bar while the scene is loading
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progress;

            // If loading is almost done, activate the scene
            if (operation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(1f); // Optional delay
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

        // Hide the loading screen once the scene is fully loaded
        loadingScreen.SetActive(false);
    }

}
*/