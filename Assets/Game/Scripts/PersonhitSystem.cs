using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PersonhitSystem : MonoBehaviour
{


    #region Fields
    Animator anim;
    bool isHit;
    #endregion

    #region Unity Methods
    private void Start()
    {
        anim = this.GetComponent<Animator>();
        this.isHit = false;
    }
    #endregion

    #region Private Methods

    #endregion
    #region OntriggerXXX
    private void OnTriggerEnter(Collider other)
    {
        
        var cut = other.gameObject.GetComponent<CutCalculator>();
        if (cut && !this.isHit) // collision is main falling down object
        {
            this.isHit = true;
            anim.enabled = false;
            
            EventManager.OnPersonDied.Invoke();
            Destroy(this.GetComponent<PersonhitSystem>());
            // inform score system and count this hit
        }
    }
    #endregion
}
