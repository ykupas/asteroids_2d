using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Private variables
    private float _respawnRate = 3.0f;
    private float _noCollisionPeriod = 3.0f;

    // Public variables
    public Player player;
    public int lives = 4;

    // Player calling game manager saying it died
    public void PlayerDied()
    {
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
