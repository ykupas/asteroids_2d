using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    // Public variables
    public Powerup powerupPrefab;
    public float spawnRate = 20.0f;
    public float spawnDistance = 15.0f;
    public float spawnTrajectoryVariance = 15.0f;
    public int spawnAmount = 1;
    


    // Start is called before the first frame update
    private void Start()
    {
        // Invoking Spawn function periodically
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    // Spawn powerup task
    private void Spawn()
    {
        // Instantiate multiples asteroids
        for(int i = 0 ; i < this.spawnAmount ; i++)
        {
            // Random position using insideUnitCircle normilized 
            Vector3 random = Random.insideUnitCircle.normalized;
            Vector3 spawnDirection = random * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            // Random rotation in Z axis using variance
            float variance = Random.Range(-this.spawnTrajectoryVariance, this.spawnTrajectoryVariance);
            Quaternion spawnRotation = Quaternion.AngleAxis(variance, Vector3.forward);

            // Instantiate powerup
            Powerup powerup = Instantiate(powerupPrefab, spawnPoint, spawnRotation);

            // Set trajectory pointed to negative spawn direction
            powerup.SetTrajectory(spawnRotation * -spawnDirection);
        }
    }
}
