using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Private variables, like components of gameObject
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    // Public variables, like sprites
    public Sprite[] sprites;

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
        _spriteRenderer.sprite = this.sprites[Random.Range(0, tjis.sprites.length)];
        // Randomization of rotation
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);

        
    }
}
