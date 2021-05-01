using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var objtag = collision.gameObject.tag;

        if (objtag == "Asteroid" || objtag == "SmallAsteroid")
        {
            Destroy(gameObject);
        }
    }
}
