using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Private variable
    private float _timeToDestroy = 0.5f;

    // Start is called before the first frame update
    private void Start()
    {
        // Destroy it after 0.5s
        Destroy(this.gameObject, _timeToDestroy);
    }
}
