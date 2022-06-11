using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Private variables
    private float _respawnRate = 3.0f;
    private float _noCollisionPeriod = 3.0f;

    // Public variables
    public Player player;
    public ParticleSystem explosion;
    public int lives = 3;
    public int score = 0;
    public Text livesText;
    public Text scoreText;
    public Text gameOverText;
    public Text continueText;

    // Static variables
    public static bool gameIsPaused = false;

    // Respawning player
    private void Respawn()
    {
        // Reseting position
        this.player.gameObject.transform.position = Vector3.zero;
        // Disable collisions for some seconds
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

    // Game over function
    private void GameOver()
    {
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

            } else{

            }
        }    
    }

    // Pause the game
    private void Pause()
    {
        
    }

    // Resume from pause game
    private void Resumo()
    {

    }

    // Asteroid destruction for call particle effect
    public void AsteroidDestroyed(Asteroid asteroid)
    {        
        // Play particle effect
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

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
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

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

    // Called at start up point
    public void Start()
    {
        // Update texts as it starts
        this.livesText.text = "Lives: x" + this.lives.ToString();
        this.scoreText.text = "Score: " + this.score.ToString();
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
