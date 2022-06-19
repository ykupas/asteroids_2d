using UnityEngine;

public class Boundary : MonoBehaviour
{
    // Public variables for boundaries
    public GameObject top;
    public GameObject bottom;
    public GameObject left;
    public GameObject right;

    // Start is called before the first frame update
    public void Start()
    {
        // Get screen size in Vector3
        Vector3 viewPoint = new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z);
        // Pass it to world point Vector2
        Vector2 viewScreen = Camera.main.ScreenToWorldPoint(viewPoint);
        // Set boundaries positions
        // TODO
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
