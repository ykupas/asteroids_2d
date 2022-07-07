using UnityEngine;


public class Powerup : MonoBehaviour
{
    // Private variables, like components of gameObject
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private int _powerupId = 0;

    // Public variables, like powerupSprites
    public Sprite[] powerupSprites;
    public float speed = 3.0f;
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
        _powerupId = Random.Range(0, this.powerupSprites.Length);
        _spriteRenderer.sprite = this.powerupSprites[_powerupId];
        // Randomization of rotation
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
    }

    // Function called when collides with something
    private void OnCollisionEnter2D(Collision2D other) 
    {
        // Collision with bullets tag
        if(other.gameObject.tag == "Bullet" || other.gameObject.tag == "Player")
        {
            // Check powerup ID
            switch(_powerupId)
            {
            case 0:
                FindObjectOfType<GameManager>().PowerupLife();
                break;

            case 1:
                FindObjectOfType<GameManager>().PowerupMult();
                break;

            case 2:
                FindObjectOfType<GameManager>().NoCollision();
                break;

            default:
                break;
            }
            // Destroy actual powerup
            Destroy(this.gameObject);
        }
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
