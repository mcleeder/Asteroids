using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenSpinRoid : MonoBehaviour
{

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(Vector3.down * 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
