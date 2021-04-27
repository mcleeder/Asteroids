using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{

    public GameObject SmallAsteroidPrefab;

    // Update is called once per frame
    void Update()
    {
        Helpers.ZAxisMovementClamp(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            SpawnSmallAsteroids();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void SpawnSmallAsteroids()
    {
        for (float y = -.15f; y < .30f; y += .30f)
        {
            for (float x = -.15f; x < .30f; x += .30f)
            {
                var grid = new Vector3(x,y,0f);
                var roid = Instantiate(SmallAsteroidPrefab, transform.position + grid, Random.rotation);
                roid.GetComponent<Rigidbody>().AddExplosionForce(10f, transform.position, 0f);
            }
        }
    }
}
