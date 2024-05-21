using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the next scene index
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index exists in the build settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {          
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels!");
            // Load the first level or main menu if there are no more levels
            // SceneManager.LoadScene(0); // Uncomment to loop back to the first scene
        }
    }
}