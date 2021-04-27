using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "KnownSpace")
        {
            Destroy(gameObject);
        }
    }
}
