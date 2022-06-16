using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Private variables for screen size
    private List<int> widths = new List<int>() {800, 1280, 1920};
    private List<int> heights = new List<int>() {600, 800, 1080};

    // Public variable for high score
    public int initScore = 0;
    public Text highScoreTex;

    // Public variables for Texts
    public Text start;
    public Text options;
    public Text quit;
    public Text back;
    public Text resulution;
    public Dropdown resulutionDropdown;
    public Toggle fullscreen;

    // Start up function
    private void Start() 
    {
        // Checking high score
        int highScore = PlayerPrefs.GetInt("HighScore", initScore);
        // Updating high score text
        highScoreTex.text = "HIGH SCORE: " + highScore.ToString();
        // Calling back to menu
        this.BackToMenu();
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
        back.gameObject.SetActive(true);
        resulution.gameObject.SetActive(true);
        resulutionDropdown.gameObject.SetActive(true);
        fullscreen.gameObject.SetActive(true);
    }

    // Back to main menu
    public void BackToMenu()
    {
        start.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        back.gameObject.SetActive(false);
        resulution.gameObject.SetActive(false);
        resulutionDropdown.gameObject.SetActive(false);
        fullscreen.gameObject.SetActive(false);
    }

    // Set screen size
    public void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }

    // Set fullscreen function
    public void SetFullscreen(bool fs)
    {
        Screen.fullScreen = fs;
    }
}
