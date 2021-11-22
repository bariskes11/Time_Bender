using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDeltaTracker 
{
    private Touch touch;
    public Vector3 GetDelta()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                return touch.deltaPosition;
            }
        }
        return Vector3.zero;
    }

    public Vector3 GetNormalizedDelta(Vector3 pos)
    {
        return pos.normalized;
    }

    

    
}
