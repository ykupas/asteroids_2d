using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Private variables for screen size
    private List<int> widths = new List<int>() {800, 1280, 1920};
    private List<int> heights = new List<int>() {600, 800, 1080};
    private int _index;
    private bool _fullscreen;
    private float _rotationSpeed;
    private float _thrustSpeed;

    // Public variable for high score
    public Text highScoreText;

    // Public variables for Texts
    public Text start;
    public Text options;
    public Text quit;
    public Text back;
    public Text apply;
    public Text defaultValues;
    public Text resulution;
    public Dropdown resulutionDropdown;
    public Toggle fullscreen;
    public Text rotationText;
    public Slider rotationSlider;
    public Text thrustText;
    public Slider thrustSlider;

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
        // Check fullscreen toggle value and set it
        if(PlayerPrefs.GetInt("Fullscreen", 1) == 1){
            this.fullscreen.isOn = true;
        }else{
            this.fullscreen.isOn = false;
        }

        // Set dropdown value
        _index = PlayerPrefs.GetInt("ResolutionIndex", 0);
        this.resulutionDropdown.value = _index;

        // Set sliders values
        _rotationSpeed = PlayerPrefs.GetFloat("RotationSpeed", 0.1f);
        _thrustSpeed = PlayerPrefs.GetFloat("ThrustSpeed", 3f);
        this.rotationSlider.value = _rotationSpeed;
        this.thrustSlider.value = _thrustSpeed;

        // Disable main menu
        this.start.gameObject.SetActive(false);
        this.options.gameObject.SetActive(false);
        this.quit.gameObject.SetActive(false);

        // Enable options menu
        this.back.gameObject.SetActive(true);
        this.apply.gameObject.SetActive(true);
        this.defaultValues.gameObject.SetActive(true);
        this.resulution.gameObject.SetActive(true);
        this.resulutionDropdown.gameObject.SetActive(true);
        this.fullscreen.gameObject.SetActive(true);
        this.rotationText.gameObject.SetActive(true);
        this.rotationSlider.gameObject.SetActive(true);
        this.thrustText.gameObject.SetActive(true);
        this.thrustSlider.gameObject.SetActive(true);        
    }

    // Back to main menu
    public void BackToMenu()
    {
        // Enable main menu
        this.start.gameObject.SetActive(true);
        this.options.gameObject.SetActive(true);
        this.quit.gameObject.SetActive(true);

        // Disable options menu
        this.back.gameObject.SetActive(false);
        this.apply.gameObject.SetActive(false);
        this.defaultValues.gameObject.SetActive(false);
        this.resulution.gameObject.SetActive(false);
        this.resulutionDropdown.gameObject.SetActive(false);
        this.fullscreen.gameObject.SetActive(false);
        this.rotationText.gameObject.SetActive(false);
        this.rotationSlider.gameObject.SetActive(false);
        this.thrustText.gameObject.SetActive(false);
        this.thrustSlider.gameObject.SetActive(false);
    }

    // Set screen size index
    public void SetScreenSize(int index)
    {
        _index = index;
    }

    // Set fullscreen function
    public void SetFullscreen(bool fs)
    {
        _fullscreen = fs;
    }

    // Set rotation speed
    public void SetRotationSpeed(float rot)
    {
        _rotationSpeed = rot;
    }

    // Set thrust speed 
    public void SetThrustSpeed(float thr)
    {
        _thrustSpeed = thr;
    }

    // Apply screen resolution modifications
    public void ApplyScreenResolution()
    {
        // Store resolutions options values 
        PlayerPrefs.SetInt("ResolutionIndex", _index);

        // Check and store fullscreen (does not have SetBool in PlayerPrefs)
        if(_fullscreen){
            PlayerPrefs.SetInt("Fullscreen", 1);
        }else{
            PlayerPrefs.SetInt("Fullscreen", 0);
        }

        // Store player options values
        PlayerPrefs.SetFloat("RotationSpeed", _rotationSpeed);
        PlayerPrefs.SetFloat("ThrustSpeed", _thrustSpeed);

        // Set options values
        Screen.SetResolution(widths[_index], heights[_index], _fullscreen);
    }

    // Default button action
    public void DefaultOptions()
    {
        // Set all options values to default
        _index = 0;
        _fullscreen = true;
        _rotationSpeed = 0.1f;
        _thrustSpeed = 3f;

        // Call apply
        ApplyScreenResolution();
        
        // Call options window again
        GoToOptions();
    }
}
