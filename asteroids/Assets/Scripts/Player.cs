using UnityEngine;

public class Player : MonoBehaviour
{
    // Private variables
    private Rigidbody2D _rigidbody2D;
    private float _thrust = 0.0f;        // (Thrust = Impulso)
    private float _thrustSpeed = 2.0f; 
    private float _torque = 0.0f;
    private float _torqueSpeed = 0.1f;

    // Awake is called at load time
    private void Awake() 
    {
        // Attach ridigbody from Player Game Object
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
            _torque = -1.0f;
        // Check right arrow negative torque
        else if(Input.GetKey(KeyCode.RightArrow))
            _torque = 1.0f;
        // If neither is pressed, torque is off
        else
            _torque = 0.0f;
    }

    // FixedUpdate is called in a fixed period
    private void FixedUpdate() 
    {
        // Add thrust when it is on
        if(_thrust != 0.0f)
            _rigidbody2D.AddForce(this.transform.up * _thrust * _thrustSpeed);

        // Add torque when it is on
        if(_torque != 0.0f)
            _rigidbody2D.AddTorque(_torque * _torqueSpeed);
        
    }
}
