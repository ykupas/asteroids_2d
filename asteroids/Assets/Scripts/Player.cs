using UnityEngine;

public class Player : MonoBehaviour
{
    // Private variables 
    private Rigidbody2D _rigidbody;
    private float _thrust = 0.0f;        // (Thrust = Impulso)
    private float _rotation = 0.0f;
    private float _thrustSpeed; 
    private float _rotationSpeed;

    // Public variables (need "this." when using)    
    public Bullet bulletPrefab;
    public GameManager gameManager;

    // Awake is called at load time
    private void Awake() 
    {
        // Attach ridigbody from Player Game Object
        _rigidbody = this.GetComponent<Rigidbody2D>();

        // Getting speed values stored
        _rotationSpeed = PlayerPrefs.GetFloat("RotationSpeed", 0.1f);
        _thrustSpeed = PlayerPrefs.GetFloat("ThrustSpeed", 3f);

        // Initiating values
        _thrust = 0.0f;
        _rotation = 0.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        // Check up arrow for forward thrust
        if(Input.GetKey(KeyCode.UpArrow))
            _thrust = 1.0f;
        // Check up arrow for break
        else if(Input.GetKey(KeyCode.DownArrow))
            _thrust = -1.0f;
        // If neither is pressed, thrust is off
        else
            _thrust = 0.0f;

        // Check  left arrow for positive torque
        if(Input.GetKey(KeyCode.LeftArrow))
            _rotation = 1.0f;
        // Check right arrow negative torque
        else if(Input.GetKey(KeyCode.RightArrow))
            _rotation = -1.0f;
        // If neither is pressed, torque is off
        else
            _rotation = 0.0f;

        // Check if shoot is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Call shoot
            this.Shoot();
        }
    }

    // FixedUpdate is called in a fixed period
    private void FixedUpdate() 
    {
        // Add thrust when it is on
        if(_thrust != 0.0f)
            _rigidbody.AddForce(this.transform.up * _thrust * _thrustSpeed);

        // Add torque when it is on
        if(_rotation != 0.0f)
            _rigidbody.AddTorque(_rotation * _rotationSpeed);   
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        // Check tag to find asteroid
        if(other.gameObject.tag == "Asteroid"){
            // Reseting speed
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;
            // Tell game manager that it died
            gameManager.PlayerDied();
            // Inactivate player 
            this.gameObject.SetActive(false);
        }        
    }

    // Shooting bullets task
    public void Shoot()
    {
        // Instantiate bullet
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        // Call project task
        bullet.Project(this.transform.up);
    }
}
