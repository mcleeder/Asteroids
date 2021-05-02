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
    public AudioSource projectileSound;
    public AudioSource thrusterSound;
    public AudioClip projectileSoundClip;

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
        RocketEffects();
        Helpers.ZAxisMovementClamp(transform);
    }

    private void RocketEffects()
    {
        if (shipVerticalAxis == 1)
        {
            ps.Play();
            thrusterSound.enabled = true;
        }
        else
        {
            ps.Stop();
            thrusterSound.enabled = false;
        }
    }

    private void ShipShoot()
    {
        var proj = Instantiate(projectilePrefab,transform.position, transform.rotation);
        proj.GetComponent<Rigidbody>().AddForce(transform.rotation * Vector3.forward * .5f, ForceMode.Impulse);
        projectileSound.PlayOneShot(projectileSoundClip);
    }

    void FixedUpdate()
    {
        if (shipVerticalAxis == 1)
        {
            rb.AddForce(Quaternion.Euler(0f, -180f, shipDirection) * new Vector3(-1f, 0f, 0f) * shipVerticalAxis);
        }
    }
}
