using UnityEngine;

public class AsteroidRandomizer : MonoBehaviour
{

    public GameObject asteroidBigPrefab;
    public GameObject asteroidSmallPrefab;
    private GameObject player;
    private float bigAsteroidSpawnTimer;
    private float smallAsteroidSpawnTimer;
    private float slowShipTimer;

    private GameObject[] asteroids;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ThrowBigAsteroidAtPlayer();
    }

    void Update()
    {
        asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        bigAsteroidSpawnTimer += Time.deltaTime;
        smallAsteroidSpawnTimer += Time.deltaTime;

        BigAsteroidSpawnerSystem();
        SmallAsteroidSpawnerSystem();

    }

    private void BigAsteroidSpawnerSystem()
    {
        //Spawn big roid every 10 seconds when there are none left
        if (bigAsteroidSpawnTimer > 10f && asteroids.Length < 1)
        {
            ThrowBigAsteroidAtPlayer();
            bigAsteroidSpawnTimer = 0f;
        }

        //Spawn faster big roid at 20 seconds regardless
        if (bigAsteroidSpawnTimer > 20f)
        {
            ThrowBigAsteroidAtPlayer(1.2f);
            bigAsteroidSpawnTimer = 0f;
        }
    }

    private void SmallAsteroidSpawnerSystem()
    {
        //if the player is moving too slow start counting
        if (player.GetComponent<Rigidbody>().velocity.magnitude < .8f)
        {
            slowShipTimer += Time.deltaTime;
        }
        else { slowShipTimer = 0f; }

        //Spawn small roid if the player is slow for 4 seconds
        if (slowShipTimer > 4f && smallAsteroidSpawnTimer > 20f)
        {
            ThrowSmallAsteroidAtPlayer();
            smallAsteroidSpawnTimer = 0f;
            slowShipTimer = 0f;
        }
    }

    private void ThrowBigAsteroidAtPlayer(float speed = 1f)
    {
        var spawnLocation = RandomViewCorner();
        var angleToPlayer = player.transform.position - spawnLocation;
        SpawnAsteroid(asteroidBigPrefab, spawnLocation, angleToPlayer);
    }

    private void ThrowSmallAsteroidAtPlayer(float speed = .8f)
    {
        var spawnLocation = RandomViewCorner();
        var angleToPlayer = player.transform.position - spawnLocation;
        SpawnAsteroid(asteroidSmallPrefab, spawnLocation, angleToPlayer, speed);
    }

    private Vector3 RandomViewCorner()
    {
        var cam = Camera.main;
        Vector3 randomCorner = new Vector3(Random.Range(0, 2), Random.Range(0, 2), 0f);
        return cam.ViewportToWorldPoint(randomCorner);
    }

    public void SpawnAsteroid(GameObject prefab, Vector3 location, Vector3 direction, float speed = 1f)
    {
        var roid = Instantiate(prefab, location, Random.rotation);
        roid.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(direction) * speed, ForceMode.Impulse);
        roid.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f) * 2f, 0f));
    }
}
