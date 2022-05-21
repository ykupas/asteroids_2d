using UnityEngine;

public class Player : MonoBehaviour
{
    // Private variables
    private Rigidbody2D _rigidbody2D;
    private float _thrust = 0.0;
    private float _thrustSpeed = 1.0; // (Impulso)
    private float _torque = 0.0;
    private float _torqueSpeed = 1.0;

    // Awake is called at load time
    private void Awake() 
    {
        // Attach ridigbody from Player Game Object
        _rigidbody2D = this.GameObject<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {

        }        
    }

    // FixedUpdate is called in a fixed period
    private void FixedUpdate() 
    {
        
    }
}
