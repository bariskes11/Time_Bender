using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicHardCodeds;

[RequireComponent(typeof(AudioSource))]
public class SuccesPoint : MonoBehaviour
{

    [SerializeField]
    ParticleSystem confetties;
    #region Fields
    AudioSource audiosource;
    #endregion

    #region Unity Methods
    private void Start()
    {
        audiosource = this.GetComponent<AudioSource>();

    }

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagNames.Human.ToString()))
        {
            EventManager.OnGameSuccess.Invoke();
           var animcntr=  other.gameObject.GetComponent<NPC_TimeAnimController>();
            animcntr.PlayVictoryAnim();
            PlayFinishConfetti();
            audiosource.Play();
        }
    }

    void PlayFinishConfetti()
    {
        confetties.Play();
    }
}
