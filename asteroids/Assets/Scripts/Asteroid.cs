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
    public float maxSize = 1.5f;
    public float speed = 10.0f;
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


    public void SetTrajectory(Vector2 direction)
    {
        // Add force to expecific direction 
        _rigidbody.AddForce(direction * this.speed);
        // Destroy game object after maxLifeTime
        Destroy(this.gameObject, this.maxLifeTime);
    }
}
