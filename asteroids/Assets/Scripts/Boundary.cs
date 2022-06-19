using UnityEngine;

public class Boundary : MonoBehaviour
{
    // Public variables for boundaries
    public GameObject top;
    public GameObject bottom;
    public GameObject right;
    public GameObject left;

    // Start is called before the first frame update
    public void Start()
    {
        // Get screen size in Vector3
        Vector3 viewPoint = new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z);
        // Pass it to world point Vector2
        Vector2 viewScreen = Camera.main.ScreenToWorldPoint(viewPoint);
        // Set boundaries positions
        this.top.transform.position = new Vector3(viewScreen.x, this.top.transform.position.y, 0f);
        this.bottom.transform.position = new Vector3(-viewScreen.x, this.bottom.transform.position.y, 0f);
        this.right.transform.position = new Vector3(this.right.transform.position.x, viewScreen.y, 0f);
        this.left.transform.position = new Vector3(this.left.transform.position.x, -viewScreen.y, 0f);
    }
}
