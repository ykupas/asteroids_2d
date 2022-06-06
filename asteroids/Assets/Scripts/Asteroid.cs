using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Private variables, like components of gameObject
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    // Public variables, like sprites, size (used by spawner)
    public Sprite[] sprites;
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 2.0f;
    public float speed = 7.0f;
    public float maxLifeTime = 30.0f;

    // Awake is called at load time
    private void Awake() 
    {
        // Linking components of objects
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Randomize size, rotation and sprite
    private void Start() 
    {
        // Randomization of sprite selection
        _spriteRenderer.sprite = this.sprites[Random.Range(0, this.sprites.Length)];
        // Randomization of rotation
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);

        /* Randomization of size */
        // Random scale of sprite and mass using size
        // Vector3.one * this.size = new Vector3(this.size,this.size,this.size)
        this.transform.localScale = Vector3.one * this.size;
        _rigidbody.mass = this.size;
    }

    // Function called when collides with something
    private void OnCollisionEnter2D(Collision2D other) 
    {
        // Collision with bullets tag
        if(other.gameObject.tag == "Bullet")
        {
            // Check if asteroid size has at least 2 minSize asteroids
            if((this.size * 0.5f) >= this.minSize)
            {
                // Create 2 halfs of asteroid
                CreateSplit();
                CreateSplit();
            }
            // Call game manager to play particle effects
            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            // Destroy actual asteroid
            Destroy(this.gameObject);
        }
    }

    // Creating asteroid split task to divide asteroid
    // when it has at least 2 minSize asteroids size
    private void CreateSplit()
    {
        // Spawn a new asteroid with new position, 
        // same rotation, half size and random trajectory
        Vector2 position = (Vector2)this.transform.position + Random.insideUnitCircle * 0.5f;
        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);
    }

    // Give the trajectory a direction
    public void SetTrajectory(Vector2 direction)
    {
        // Add force to expecific direction 
        _rigidbody.AddForce(direction * this.speed);
        // Destroy game object after maxLifeTime
        Destroy(this.gameObject, this.maxLifeTime);
    }
}
