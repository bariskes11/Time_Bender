using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_MovementController : NPC_Base
{
    [SerializeField]
    float normalRunSpeed;
    [SerializeField]
    [Header("This value can be *2 or /2")]
    float sloworFasterSpeedMultiply;
    [SerializeField]
    Transform targetPosition;

    #region Fields
    
    bool isStarted;

    #endregion
    #region Properties
    private float currentSpeed;
    public float CurrentSpeed
    {
        get => this.currentSpeed;
        set => this.currentSpeed = value;
    }
    #endregion
    protected override void Start()
    {
        base.Start();
        currentSpeed = normalRunSpeed;
        EventManager.OnFasterButtonPressed.AddListener(this.SetFasterSpeed);
        EventManager.OnSlowDownButtonPressed.AddListener(this.SetSlowDownSpeed);
    }
   protected override void SetSlowDownSpeed()
    {
        base.SetSlowDownSpeed();
        if(interaction.IsAimed)
        currentSpeed = normalRunSpeed / sloworFasterSpeedMultiply;
    }
    protected override void SetFasterSpeed()
    {
        base.SetFasterSpeed();
        if (interaction.IsAimed)
            currentSpeed = normalRunSpeed * sloworFasterSpeedMultiply;

    }
    protected override void SetStartStatus()
    {
        base.SetStartStatus();
        currentSpeed = normalRunSpeed;
    }
    protected override void Update()
    {
        base.Update();
        if (!this.iscontrolstarted)
            return;
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition.position, currentSpeed * Time.deltaTime);
    }
}
