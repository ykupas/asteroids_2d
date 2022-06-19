using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Private variables for screen size
    private List<int> widths = new List<int>() {800, 1280, 1920};
    private List<int> heights = new List<int>() {600, 800, 1080};
    private bool _fullscreen;
    private int _width;
    private int _height;

    // Public variable for high score
    public Text highScoreText;

    // Public variables for Texts
    public Text start;
    public Text options;
    public Text quit;
    public Text back;
    public Text apply;
    public Text resulution;
    public Dropdown resulutionDropdown;
    public Toggle fullscreen;

    // Start up function
    private void Start() 
    {
        // Checking high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        // Updating high score text
        this.highScoreText.text = "HIGH SCORE: " + highScore.ToString();
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
        this.start.gameObject.SetActive(false);
        this.options.gameObject.SetActive(false);
        this.quit.gameObject.SetActive(false);
        this.back.gameObject.SetActive(true);
        this.apply.gameObject.SetActive(true);
        this.resulution.gameObject.SetActive(true);
        this.resulutionDropdown.gameObject.SetActive(true);
        this.fullscreen.gameObject.SetActive(true);
    }

    // Back to main menu
    public void BackToMenu()
    {
        this.start.gameObject.SetActive(true);
        this.options.gameObject.SetActive(true);
        this.quit.gameObject.SetActive(true);
        this.back.gameObject.SetActive(false);
        this.apply.gameObject.SetActive(false);
        this.resulution.gameObject.SetActive(false);
        this.resulutionDropdown.gameObject.SetActive(false);
        this.fullscreen.gameObject.SetActive(false);
    }

    // Set screen size
    public void SetScreenSize(int index)
    {
        _width = widths[index];
        _height = heights[index];
    }

    // Set fullscreen function
    public void SetFullscreen(bool fs)
    {
        _fullscreen = fs;
    }

    // Apply screen resolution modifications
    public void ApplyScreenResolution()
    {
        Screen.SetResolution(_width, _height, _fullscreen);
    }
}
