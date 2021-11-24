using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicHardCodeds;

public class NPC_Base : MonoBehaviour
{
    #region Properties
    protected bool iscontrolstarted;
    public bool IsControlstarted
    {
        get => this.iscontrolstarted;
        set => this.iscontrolstarted = value;
    }
    protected bool isAimed;
    public bool IsAimed
    {
        get => this.isAimed;
        set=>this.isAimed = value;
    }

    protected virtual void Start()
    {
        EventManager.OnGameStarted.AddListener(this.SetStartStatus);
        EventManager.OnFasterButtonPressed.AddListener(this.SetFasterSpeed);
        EventManager.OnSlowDownButtonPressed.AddListener(this.SetSlowDownSpeed);

    }
    protected virtual void Update()
    {
        if (!iscontrolstarted)
            return;
        if (!IsAimed)
            return;
    }
    protected virtual void SetStartStatus()
    {
        this.iscontrolstarted = true;
    }
    protected virtual void SetFasterSpeed()
    {
        if (!IsAimed)
            return;
    }
    protected virtual void SetSlowDownSpeed()
    {
        if (!IsAimed)
            return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagNames.DangerObj.ToString()))
        {
            //play some particles
            this.GetComponent<Animator>().enabled = false;
            this.iscontrolstarted = false;
        }
    }

    #endregion

}
