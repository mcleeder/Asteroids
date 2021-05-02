using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroidCollision : MonoBehaviour
{

    public ParticleSystem ExplosionPrefab;
    public AudioClip explosionSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            Scoreboard.ScoreSmallAsteroid();
            Destroy(other.gameObject);
            ParticleExplode();
            AudioController.Instance.Play(explosionSound, .25f);
            Destroy(gameObject);
        }
    }

    private void ParticleExplode()
    {
        var explosion = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        explosion.Play();
    }
}
