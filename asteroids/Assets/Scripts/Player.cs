using UnityEngine;

public class Player : MonoBehaviour
{
    // Private variables 
    private Rigidbody2D _rigidbody;
    private float _thrust = 0.0f;        // (Thrust = Impulso)
    private float _torque = 0.0f;

    // Public variables (need "this." when using)
    public float _thrustSpeed = 3.0f; 
    public float _torqueSpeed = 0.1f;
    public Bullet bulletPrefab;

    // Awake is called at load time
    private void Awake() 
    {
        // Attach ridigbody from Player Game Object
        _rigidbody = this.GetComponent<Rigidbody2D>();
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
            _torque = 1.0f;
        // Check right arrow negative torque
        else if(Input.GetKey(KeyCode.RightArrow))
            _torque = -1.0f;
        // If neither is pressed, torque is off
        else
            _torque = 0.0f;

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
            _rigidbody.AddForce(this.transform.up * _thrust * this._thrustSpeed);

        // Add torque when it is on
        if(_torque != 0.0f)
            _rigidbody.AddTorque(_torque * this._torqueSpeed);   
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        // Check tag to find asteroid
        if(other.gameObject.tag == "Asteroid"){
            // Reseting speed
            _ridigbody.velocity = Vector3.zero;
            _ridigbody.angulaVelocity = 0.0f;
            // Tell game manager that it died
            // TODO
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
