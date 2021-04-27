using System;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    private float shipDirection;
    public float shipDirectionMultiplier = 200f;
    private float shipVerticalAxis;
    private Rigidbody rb;
    private ParticleSystem ps;
    public GameObject projectilePrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        shipDirection += Input.GetAxis("Horizontal") * Time.deltaTime * shipDirectionMultiplier;
        shipVerticalAxis = Input.GetAxis("Vertical");
        transform.rotation = Quaternion.Euler(shipDirection,90f,-90f);

        if (Input.GetKeyDown(KeyCode.Space)) {
            ShipShoot();
        }
        RocketEmission();
        Helpers.ZAxisMovementClamp(transform);
    }

    private void RocketEmission()
    {
        var emission = ps.emission;
        if (shipVerticalAxis == 1)
        {
            emission.enabled = true;
        }
        else
        {
            emission.enabled = false;
        }
    }

    private void ShipShoot()
    {
        var proj = Instantiate(projectilePrefab,transform.position, Quaternion.identity);
        proj.GetComponent<Rigidbody>().AddForce(transform.rotation * Vector3.forward * .5f, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        rb.AddForce(Quaternion.Euler(0f, -180f, shipDirection) * new Vector3(-1f,0f,0f) * shipVerticalAxis);
    }
}
