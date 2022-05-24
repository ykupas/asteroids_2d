using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // Public variables
    public float spawnRate = 2.0f;


    // Start is called before the first frame update
    private void Start()
    {
        // Invoking Spawn function
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    // Spawn asteroid task
    private void Spawn()
    {

    }

    // Update is called once per frame
    private  void Update()
    {
        
    }
}
