using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ObjectControllerBase))]
public class CarChrushSystem : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    GameObject carChrushparticle;
    [SerializeField]
    float hitMultiplayer;


    [SerializeField]
    float randomForce;
    #endregion
    #region Fields
    Rigidbody objRigidBody;
    ObjectControllerBase objcontroller;
    GameObject cachedChrushParticle;
    #endregion

    #region Properties
    private bool isSaved;
    public bool IsSaved
    {
        get => this.isSaved;
        set => this.isSaved = value;
    }
    #endregion


    #region Unity Methods
    private void Start()
    {
        this.isSaved = false;
        cachedChrushParticle = Instantiate(carChrushparticle);
        objRigidBody = this.GetComponent<Rigidbody>();
        objcontroller = this.GetComponent<ObjectControllerBase>();
    }

    #endregion
    #region OnColliderXXX
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IInteractable>() != null) // its an interactable object
        {
            collision.gameObject.GetComponent<IInteractable>().RemoveInteract();
            objcontroller.IsControlstarted = false; // thisable object move
            objRigidBody.AddForce(Vector3.up * hitMultiplayer * Random.Range(1, randomForce));
            objRigidBody.AddTorque(Vector3.up * hitMultiplayer * Random.Range(1, randomForce));
            cachedChrushParticle.transform.position = collision.contacts[0].point;
            cachedChrushParticle.GetComponent<ParticleSystem>().Play();
            // find player camera and rotate toward fail point
            FindObjectOfType<FpsController>().LookAtTargetPoint(cachedChrushParticle.transform.position);
            // stop all cars

            EventManager.OnGameFail.Invoke();

        }
    }
    #endregion
}
