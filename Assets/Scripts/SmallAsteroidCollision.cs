using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroidCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
