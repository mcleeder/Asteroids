using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRandomizer : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public int AsteroidSeedCount;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < AsteroidSeedCount; i++)
        {
            var location = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
            var rotation = Quaternion.Euler(Random.Range(-90f, 90f), Random.Range(-90f, 90f), Random.Range(-90f, 90f));
            Instantiate(asteroidPrefab, location, rotation);
        }

        var asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        for (int i = 0; i < asteroids.Length; i++)
        {
            asteroids[i].GetComponent<Rigidbody>().AddForce(Vector3.Normalize(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f)), ForceMode.Impulse);
            asteroids[i].GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f) * 2f);
        }
    }
}
