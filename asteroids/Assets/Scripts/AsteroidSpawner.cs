using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // Public variables
    public Asteroid asteroidPrefab;
    public float spawnRate = 2.0f;
    public float spawnDistance = 15.0f;
    public int spawnAmount = 3;


    // Start is called before the first frame update
    private void Start()
    {
        // Invoking Spawn function periodically
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    // Spawn asteroid task
    private void Spawn()
    {
        // Instantiate multiples asteroids
        for(int i = 0 ; i < this.spawnAmount ; i++)
        {
            Vector3 random = Random.insideUnitCircle.normalized;
            Debug.Log("Random value = " + random);
            Vector3 spawnDirection = random * this.spawnDistance;
            Debug.Log("Spawn direction value = " + spawnDirection);
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            Debug.Log("Spawn point value = " + spawnPoint);

            Quaternion spawnRotation = Quaternion.identity;

            // Instantiate asteroid
            Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, spawnRotation);
        }
    }

    // Update is called once per frame
    private  void Update()
    {
        
    }
}
