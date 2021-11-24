using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : InteractionSystem
{

    #region Fields
    Rigidbody rigidbdy;
    #endregion
    #region Unity Methods
    protected override void Start()
    {
        
        base.Start();
        rigidbdy = this.GetComponent<Rigidbody>();
        EventManager.OnGameStarted.AddListener(this.SetRigidBody);
    }
    #endregion

    #region Private Methods
    void SetRigidBody()
    {
        Debug.Log("SetRigidBody Fired");
        rigidbdy.constraints = RigidbodyConstraints.None;
    }
    #endregion

}
