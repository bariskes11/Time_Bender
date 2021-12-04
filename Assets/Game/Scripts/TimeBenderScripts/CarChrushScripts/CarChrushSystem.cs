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




    #region Unity Methods
    private void Start()
    {
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
            Debug.Log($"Collided with {collision.gameObject}", collision.gameObject);
            collision.gameObject.GetComponent<IInteractable>().RemoveInteract();
            objcontroller.IsControlstarted = false; // thisable object move
            objRigidBody.AddForce(Vector3.up * hitMultiplayer * Random.Range(1, randomForce));
            objRigidBody.AddTorque(Vector3.up * hitMultiplayer * Random.Range(1, randomForce));
            cachedChrushParticle.transform.position = collision.contacts[0].point;
            cachedChrushParticle.GetComponent<ParticleSystem>().Play();

        }
    }
    #endregion
}
