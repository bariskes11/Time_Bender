using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviours : MonoBehaviour
{
    
    public void InvokeFasterMovement()
    {
        EventManager.OnFasterButtonPressed.Invoke();
        
    }

    public void InvokeSlowDownMovement()
    {
        EventManager.OnSlowDownButtonPressed.Invoke();
    }
    void KeepLastInteraction()
    {
        EventManager.OnPlayerDecideSpeed.Invoke();
    }
}
