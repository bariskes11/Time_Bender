using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviours : MonoBehaviour
{
    AudioSource audioSrc;

    private void OnEnable()
    {
        audioSrc.Play();
    }
    private void OnDisable()
    {
        audioSrc.Stop();
    }


    private void Awake()
    {
        this.gameObject.SetActive(true);
        audioSrc = this.GetComponent<AudioSource>();


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
