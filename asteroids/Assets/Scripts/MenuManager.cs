using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Load game scene function
    public void LoadGame()
    {
        // Load next index scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quit game function
    public void QuitGame()
    {
        // Quit game
        Debug.Log("QUIT");
        Application.Quit();
    }
}
