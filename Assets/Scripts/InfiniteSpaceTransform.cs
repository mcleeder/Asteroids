using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpaceTransform : MonoBehaviour
{
    bool isWrappingX = false;
    bool isWrappingY = false;
    Renderer[] renderers;

    private void Update()
    {
        ScreenWrap();
    }

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    void ScreenWrap()
    {
        var isVisible = CheckRenderers();

        if (isVisible)
        {
            isWrappingX = false;
            isWrappingY = false;
            return;
        }

        if (isWrappingX && isWrappingY)
        {
            return;
        }

        var cam = Camera.main;
        var viewportPosition = cam.WorldToViewportPoint(transform.position);
        var newPosition = transform.position;

        if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            newPosition.x = -newPosition.x;

            isWrappingX = true;
        }

        if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            newPosition.y = -newPosition.y;

            isWrappingY = true;
        }

        transform.position = newPosition;
    }

    bool CheckRenderers()
    {
        foreach (var renderer in renderers)
        {
            // If at least one render is visible, return true
            if (renderer.isVisible)
            {
                return true;
            }
        }

        // Otherwise, the object is invisible
        return false;
    }
}
