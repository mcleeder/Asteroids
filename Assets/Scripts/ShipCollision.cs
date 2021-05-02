using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour
{

    public ParticleSystem ps;

    private void OnCollisionEnter(Collision collision)
    {
        var objtag = collision.gameObject.tag;

        if (objtag == "Asteroid" || objtag == "SmallAsteroid")
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            GetComponent<ShipController>().enabled = false;
            Instantiate(ps, transform.position, transform.rotation);
        }
    }
}
