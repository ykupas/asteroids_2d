using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Public variable for high score
    public int initScore = 0;
    public Text highScoreTex;

    // Public variables for Texts
    public Text start;
    public Text options;
    public Text quit;
    public Text resulution;
    public Text back;

    // Start up function
    private void Start() 
    {
        // Checking high score
        int highScore = PlayerPrefs.GetInt("HighScore", initScore);
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

    // Load options menu
    public void GoToOptions()
    {
        start.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        resulution.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
    }

    // Back to main menu
    public void BackToMenu()
    {
        start.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        resulution.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
    }
}
