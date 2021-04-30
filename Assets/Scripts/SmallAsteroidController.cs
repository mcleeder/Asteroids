using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroidController : MonoBehaviour
{
    void Update()
    {
        Helpers.ZAxisMovementClamp(transform);
    }
}
