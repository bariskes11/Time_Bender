using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MultipleTreadsLevelPassCheck : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    ParticleSystem confettiOnTriggered;
    #endregion


    #region Fields
    List<CarChrushSystem> carcrushlist;
    AudioSource audiosource;
    #endregion

    #region Unity Methods

    private void Start()
    {
        carcrushlist= GameObject.FindObjectsOfType<CarChrushSystem>().ToList();
        audiosource = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CarChrushSystem>())
        {
            Debug.Log("Succes Trigger Entered",other.gameObject);
            other.GetComponent<CarChrushSystem>().IsSaved = true;
            this.CheckAndRiseEvent();
            confettiOnTriggered?.Play();
            audiosource.Play();
        }
    }



    #endregion
    #region Private methods
    void CheckAndRiseEvent()
    {
       var rslt=  carcrushlist.Where(x => !x.IsSaved).FirstOrDefault(); // check if there  is unsaved item
        if (!rslt)
        {
            EventManager.OnGameSuccess.Invoke();
        }
    }
    #endregion
}
