using UnityEngine;

public class AsteroidRandomizer : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public int AsteroidSeedCount;
    public int AsteroidLowerLimit;

    private GameObject[] asteroids;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < AsteroidSeedCount; i++)
        {
            SpawnRandomAsteroid();
        }
    }

    void Update()
    {
        asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        if (asteroids.Length < AsteroidLowerLimit)
        {
            SpawnRandomAsteroid();
        }
    }

    private void SpawnRandomAsteroid()
    {
        var randX = Random.Range(-10f, 10f);
        var randY = Random.Range(-10f, 10f);
        SpawnAsteroid(randX, randY);
    }

    public void SpawnAsteroid(float x, float y)
    {
        var location = new Vector3(x, y, 0f);
        var roid = Instantiate(asteroidPrefab, location, Random.rotation);
        roid.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(location), ForceMode.Impulse);
        roid.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f) * 2f, 0f));
    }
}
