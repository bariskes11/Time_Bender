using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionSystem))]
public class TimeBasedParticleManager : MonoBehaviour
{
    #region Unity Fields    
    [SerializeField]
    GameObject fastParticles;
    [SerializeField]
    GameObject slowParticles;
    #endregion
    #region Fields
    InteractionSystem interact;
    #endregion


    #region Unity methods
    private void Start()
    {
      interact=   this.GetComponent<InteractionSystem>();
        this.fastParticles.SetActive(false);
        this.slowParticles.SetActive(false);
        EventManager.OnFasterButtonPressed.AddListener(this.SetFastModeParticles);
        EventManager.OnSlowDownButtonPressed.AddListener(this.SetSlowModeParticles);
        EventManager.OnGameFail.AddListener(this.StopParticles);
        EventManager.OnGameSuccess.AddListener(this.StopParticles);

    }

    #endregion
    #region Private Methods
    void SetSlowModeParticles()
    {
        if (!this.interact.IsAimed) return;
        this.fastParticles.SetActive(false);
        this.slowParticles.SetActive(true);
    }
        
    void SetFastModeParticles()
    {
        if (!this.interact.IsAimed) return;
        this.fastParticles.SetActive(true);
        this.slowParticles.SetActive(false);

    }
    void StopParticles()
    {
        this.fastParticles.SetActive(false);
        this.slowParticles.SetActive(false);
    }
    #endregion

}
