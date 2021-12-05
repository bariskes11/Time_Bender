using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleActivator : MonoBehaviour
{
    #region OnTriggerXXX
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ObjectControllerBase>())
        {
            Debug.Log("Controller Base Collided");
            other.GetComponent<ObjectControllerBase>().IsEnabledOnTrigger = false;
        }
    }
    #endregion
}
