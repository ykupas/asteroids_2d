using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Public variable for high score
    public int highScore;
    public Text highScoreTex;

    // Start up function
    private void Start() 
    {
        // Updating high score text
        highScoreTex.text = "HIGH SCORE: " + highScore.ToString();
    }

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
