using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroidCollision : MonoBehaviour
{

    public ParticleSystem ExplosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            Scoreboard.ScoreSmallAsteroid();
            Destroy(other.gameObject);
            ParticleExplode();
            Destroy(gameObject);
        }
    }

    private void ParticleExplode()
    {
        var explosion = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        explosion.Play();
    }
}
