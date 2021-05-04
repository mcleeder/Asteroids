using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour
{

    public ParticleSystem ps;
    public AudioClip playerBoomSound;
    private IEnumerator destroyPlayerRoutine;

    private void OnCollisionEnter(Collision collision)
    {
        var objtag = collision.gameObject.tag;

        if (objtag == "Asteroid" || objtag == "SmallAsteroid")
        {
            AudioController.Instance.Play(playerBoomSound);
            destroyPlayerRoutine = DestroyPlayer();
            StartCoroutine(destroyPlayerRoutine);
        }
    }

    IEnumerator DestroyPlayer()
    {
        Instantiate(ps, transform.position, transform.rotation);

        LevelLoader.levelComplete = true;

        yield return null;

        Destroy(gameObject);

        
    }
}
