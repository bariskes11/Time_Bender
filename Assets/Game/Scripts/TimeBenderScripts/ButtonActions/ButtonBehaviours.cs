using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviours : MonoBehaviour
{


    private void Awake()
    {
        this.gameObject.SetActive(true);
    }

    public void InvokeFasterMovement()
    {
        EventManager.OnFasterButtonPressed.Invoke();
        this.gameObject.SetActive(false);
        
    }

    public void InvokeSlowDownMovement()
    {
        EventManager.OnSlowDownButtonPressed.Invoke();
        this.gameObject.SetActive(false);
    }
    void KeepLastInteraction()
    {
        EventManager.OnPlayerDecideSpeed.Invoke();
    }
}
