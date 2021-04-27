using UnityEngine;

public class Helpers : MonoBehaviour
{
    public static void ZAxisMovementClamp(Transform transform)
    {
        var newPosition = transform.position;
        newPosition.z = 0f;
        transform.position = newPosition;
    }
}
