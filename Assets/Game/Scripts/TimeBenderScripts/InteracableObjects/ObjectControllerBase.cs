using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectControllerBase : NPC_Base
{
    #region Unity Fields
    [SerializeField]
    float normalSpeed;
    [SerializeField]
    float fastSpeed;
    [SerializeField]
    float slowSpeed;
    [SerializeField]
    Vector3 direction;
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
        currentFalDownSpeed = normalSpeed;
        rgdbdy.constraints = RigidbodyConstraints.FreezeAll;
    }
    protected override void Update()
    {
        //base.Update();
        if (!iscontrolstarted)
             return;
        
       // if (this.interaction.IsAimed)
       // {
        rgdbdy.velocity = direction * currentFalDownSpeed;

      //  }

    }
    #endregion
    protected override void SetStartStatus()
    {
        base.SetStartStatus();
        rgdbdy.constraints = RigidbodyConstraints.None;
    }

    protected override void SetSlowDownSpeed()
    {

        base.SetSlowDownSpeed();
        if (this.interaction.IsAimed)
        {
            currentFalDownSpeed = slowSpeed;
        }

    }
    protected override void SetFasterSpeed()
    {
        base.SetFasterSpeed();
        if (this.interaction.IsAimed)
        {
            currentFalDownSpeed = fastSpeed;
        }
    }

    public void StopMovement()
    {
        rgdbdy.velocity = Vector3.zero;
        rgdbdy.angularVelocity = Vector3.zero;
        rgdbdy.constraints = RigidbodyConstraints.FreezeAll;
    }


}
