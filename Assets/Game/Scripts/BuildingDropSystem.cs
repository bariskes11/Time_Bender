using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BuildingDropSystem : MonoBehaviour
{
    #region Unity Fields

    [SerializeField]
    GameObject droppingObject;
    #endregion

    #region Fields
    Rigidbody rgdbody;
    #endregion
    #region Properties
    private bool isFalling;
    public bool IsFalling
    {
        get => this.isFalling;
        set => this.isFalling = value;
    }
    #endregion
    #region Unity Methods
    void Start()
    {
        rgdbody = this.GetComponent<Rigidbody>();
    }
    #endregion
    #region Public Methods

    public void StartToFall()
    {
        StartCoroutine(setStartFallCoroutine());
    }
    IEnumerator setStartFallCoroutine()
    {
        yield return new WaitForSeconds(1.2F);
        this.isFalling = true;
        SetrigidBodyFall(droppingObject.GetComponent<Rigidbody>());
        SetrigidBodyFall(this.rgdbody);
    }

    #endregion
    #region PrivateMethods
    void SetrigidBodyFall(Rigidbody bdy)
    {

        bdy.constraints = RigidbodyConstraints.None;
        bdy.isKinematic = false;
        bdy.useGravity = true;
    }
    #endregion
}
