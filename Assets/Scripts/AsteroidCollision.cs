using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{

    public GameObject SmallAsteroidPrefab;
    public ParticleSystem ExplosionPrefab;
    public float explosionForce;
    public AudioClip explosionSound;

    // Update is called once per frame
    void Update()
    {
        Helpers.ZAxisMovementClamp(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            Scoreboard.ScoreBigAsteroid();
            SpawnSmallAsteroids();
            ParticleExplode();
            AudioController.Instance.Play(explosionSound);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void ParticleExplode()
    {
        var explosion = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        explosion.Play();
    }

    private void SpawnSmallAsteroids()
    {
        float degrees = Random.Range(1f,360f);

        for (int x = 0; x < 3; x++)
        {
            Vector3 spawnRotation = (Quaternion.Euler(0f, 0f, degrees) * new Vector3(.25f,.25f,0f));
            var roid = Instantiate(SmallAsteroidPrefab, transform.position + spawnRotation, Random.rotation);
            roid.GetComponent<Rigidbody>().AddTorque(Vector3.Normalize(transform.position));
            roid.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, 0f);
            degrees += Random.Range(100f,120f);
        }
    }
}
