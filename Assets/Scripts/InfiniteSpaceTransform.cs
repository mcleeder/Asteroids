using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpaceTransform : MonoBehaviour
{

    private void Update()
    {
        Check(transform);
    }

    private void Check(Transform transform)
    {
        if (transform.position.y < -5.5f)
        {
            transform.position += new Vector3(0f, 11f, 0f);
        }

        if (transform.position.y > 5.6f)
        {
            transform.position += new Vector3(0f, -11f, 0f);
        }

        if (transform.position.x < -12.5f)
        {
            transform.position += new Vector3(25f, 0f, 0f);
        }

        if (transform.position.x > 12.6f)
        {
            transform.position += new Vector3(-25, 0f, 0f);
        }
    }
}
