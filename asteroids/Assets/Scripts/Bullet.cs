using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Private variables
    private Rigidbody2D _rigidbody;

    // Public variables (need "this." when using)
    public float bulletSpeed = 500.0f;
    public float maxLifeTime = 10.0f;

    // Awake is called at load time
    private void Awake() 
    {
        // Attach ridigbody from Bullet GameObject
        _rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Task that projects bullet called from player
    public void Project(Vector2 direction)
    {
        // Add force to expecific direction 
        _rigidbody.AddForce(direction * this.bulletSpeed);
        // Destroy game object after maxLifeTime
        Destroy(this.gameObject, this.maxLifeTime);
    }

    // Destroy when collides with something
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(this.gameObject);
    }
}
