using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Private variables
    private float _respawnRate = 3.0f;
    private float _noCollisionPeriod = 3.0f;

    // Public variables
    public Player player;
    public ParticleSystem explosionPrefab;
    public int lives = 3;
    public int score = 0;
    public Text livesText;
    public Text scoreText;
    public Text gameOverText;
    public Text continueText;
    public GameObject PauseMenu;

    // Static variables
    public static bool gameIsPaused = false;

    // Respawning player
    private void Respawn()
    {
        // Reseting position
        this.player.gameObject.transform.position = Vector3.zero;
        // Disable collisions for some seconds (boundaries are not ignored)
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        // Reactivating player
        this.player.gameObject.SetActive(true);
        // Invoking function to enable collisions
        Invoke(nameof(TurnOnCollisions), _noCollisionPeriod);
    }

    // Enable again collisions
    private void TurnOnCollisions()
    {
        // Set layer back to default
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    // GameOver task
    private void GameOver()
    {
        // Check high score and actual score
        int highScore = PlayerPrefs.GetInt("HighScore", score);
        if(highScore <= score){
            PlayerPrefs.SetInt("HighScore", score);
        }
        // Activate game over text UI
        this.gameOverText.gameObject.SetActive(true);
        this.continueText.gameObject.SetActive(true);
    }

    // Update every frame
    private void Update() 
    {
        // Check if "ESC" button is pressed
        if(Input.GetKeyDown(KeyCode.Escape)){
            // Check if game is paused
            if(gameIsPaused){
                Resume();
            } else{
                Pause();
            }
        }    
    }

    // Pause the game
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    // Resume from pause game
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    // Asteroid destruction for call particle effect
    public void AsteroidDestroyed(Asteroid asteroid)
    {        
        // Play particle effect
        ParticleSystem explosion = Instantiate(this.explosionPrefab);
        explosion.transform.position = asteroid.transform.position;
        explosion.Play();

        // Check asteroid size to score
        if(asteroid.size > 1.25){
            // Large ones
            this.score += 10;
        } else{
            // Small ones
            this.score += 5;
        }

        // Update UI for score
        this.scoreText.text = "Score: " + this.score.ToString();
    }

    // Player calling game manager saying it died
    public void PlayerDied()
    {
        // Play particle effect
        ParticleSystem explosion = Instantiate(this.explosionPrefab);
        explosion.transform.position = this.player.transform.position;
        explosion.Play();

        // Check lives count
        if(this.lives <= 0){
            GameOver();
        } else {
            // Less one live
            this.lives--;

            // Update lives UI
            this.livesText.text = "Lives: x" + this.lives.ToString();

            // Call player respawn
            Invoke(nameof(Respawn), _respawnRate);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Update texts as it starts
        this.livesText.text = "Lives: x" + this.lives.ToString();
        this.scoreText.text = "Score: " + this.score.ToString();
        // Game is not paused at start-up
        this.Resume();
    }

    // Load menu scene function
    public void LoadMenu()
    {
        // Load previous index scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Reload game scene function
    public void ReloadGame()
    {
        // Load previous index scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
