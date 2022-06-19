using UnityEngine;

public class Boundary : MonoBehaviour
{
    // Public variables for boundaries
    public GameObject top;
    public GameObject bottom;
    public GameObject right;
    public GameObject left;

    // Awake is called at load time
    private void Awake()
    {
        // Get screen size in Vector3
        Vector3 viewPoint = new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z);
        // Pass it to world point Vector2
        Vector2 viewScreen = Camera.main.ScreenToWorldPoint(viewPoint);
        // Set boundaries positions
        this.top.transform.position = new Vector3(0f, viewScreen.y, 0f);
        this.bottom.transform.position = new Vector3(0f, -viewScreen.y, 0f);
        this.right.transform.position = new Vector3(viewScreen.x, 0f, 0f);
        this.left.transform.position = new Vector3(-viewScreen.x, 0f, 0f);
    }
}
