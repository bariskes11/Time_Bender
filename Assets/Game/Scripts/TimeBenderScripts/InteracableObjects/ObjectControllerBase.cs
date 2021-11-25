using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectControllerBase : NPC_Base
{
    #region Unity Fields
    [SerializeField]
    float fasterDragMultiplyer;
    [SerializeField]
    float slowerDragMultiplyer;
    #endregion
    #region Fields
    Rigidbody rgdbdy;
    float currentFalDownSpeed;
    #endregion
    #region Unity Fields


    protected override void Start()
    {
        base.Start();
        rgdbdy = this.GetComponent<Rigidbody>();
        currentFalDownSpeed = rgdbdy.drag;
    }
    protected override void Update()
    {
        base.Update();
        if (this.interaction.IsAimed)
        {
            rgdbdy.drag = currentFalDownSpeed;
        }

    }
    #endregion


    protected override void SetSlowDownSpeed()
    {

        base.SetSlowDownSpeed();
        if (this.interaction.IsAimed)
        {
            currentFalDownSpeed = slowerDragMultiplyer;
        }

    }
    protected override void SetFasterSpeed()
    {
        base.SetFasterSpeed();
        if (this.interaction.IsAimed)
        {
            currentFalDownSpeed = fasterDragMultiplyer;
        }
    }


}
