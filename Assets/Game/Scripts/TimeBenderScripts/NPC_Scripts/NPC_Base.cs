using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicHardCodeds;

public class NPC_Base : MonoBehaviour
{
    #region Properties
    protected InteractionSystem interaction; 
    protected bool iscontrolstarted;
    public bool IsControlstarted
    {
        get => this.iscontrolstarted;
        set => this.iscontrolstarted = value;
    }
    

    protected virtual void Start()
    {
        interaction = this.GetComponentInChildren<InteractionSystem>();
        if (!interaction)
        {
            Debug.Log("<color=red>Ther is no interaction system</color>");
        }
        
        EventManager.OnGameStarted.AddListener(this.SetStartStatus);
        EventManager.OnFasterButtonPressed.AddListener(this.SetFasterSpeed);
        EventManager.OnSlowDownButtonPressed.AddListener(this.SetSlowDownSpeed);
        EventManager.OnGameFail.AddListener(this.DisableControls);
        EventManager.OnGameSuccess.AddListener(this.DisableControls);
    }
    protected virtual void Update()
    {
        if (!iscontrolstarted)
            return;
    }
    protected virtual void SetStartStatus()
    {
        this.iscontrolstarted = true;
    }
    protected virtual void SetFasterSpeed()
    {
    }
    protected virtual void SetSlowDownSpeed()
    {
     
    }
    private  void DisableControls()
    {
        this.iscontrolstarted = false;
        this.gameObject.layer = LayerMask.NameToLayer("Default");
    }


    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagNames.DangerObj.ToString()))
        {
            //play some particles
            this.GetComponent<Animator>().enabled = false;
            this.iscontrolstarted = false;
            Rigidbody rgd = other.gameObject.GetComponent<Rigidbody>();
            rgd.angularDrag = 0;
            rgd.drag = 0;
            EventManager.OnGameFail.Invoke();
        }
    }

    #endregion

}
