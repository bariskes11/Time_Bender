using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDeltaTracker
{
    public Vector3 GetDelta();
    public Vector3 GetNormalizedDelta(Vector3 pos);
}
