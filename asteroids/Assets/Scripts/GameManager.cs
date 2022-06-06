using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Private variables
    private float _respawnRate = 3.0f;
    private float _noCollisionPeriod = 3.0f;

    // Public variables
    public Player player;
    public ParticleSystem explosion;
    public int lives = 4;
    public int score = 0;

    // Asteroid destruction for call particle effect
    public void AsteroidDestroyed(Asteroid asteroid)
    {        
        // Play particle effect
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        // Check asteroid size to score
        if(asteroid.size > 1.25){
            // Large ones
            score += 10;
        } else{
            // Small ones
            score += 5;
        }

        // TODO: create a UI for score
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
            // Call player respawn
            Invoke(nameof(Respawn), _respawnRate);
        }
    }

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

    // GameOver task
    private void GameOver()
    {
        // TODO

    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
