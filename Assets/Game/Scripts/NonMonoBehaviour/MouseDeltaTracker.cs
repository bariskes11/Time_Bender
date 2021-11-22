using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseDeltaTracker 
{
    private Vector3 lastPos;
    private Vector3 deltaPos;

    public Vector3 GetDelta()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            deltaPos = lastPos - Input.mousePosition;

            return deltaPos;
        }

        return Vector3.zero;
    }



    public Vector3 GetNormalizedDelta(Vector3 vector)
    {

        return vector.normalized;
    }
}

