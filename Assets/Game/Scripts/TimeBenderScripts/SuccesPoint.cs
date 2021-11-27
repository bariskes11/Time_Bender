using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicHardCodeds;

public class SuccesPoint : MonoBehaviour
{

    [SerializeField]
    ParticleSystem confetties;
    #region Unity Methods
    
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagNames.Human.ToString()))
        {
            EventManager.OnGameSuccess.Invoke();
           var animcntr=  other.gameObject.GetComponent<NPC_TimeAnimController>();
            animcntr.PlayVictoryAnim();
            PlayFinishConfetti();

        }
    }

    void PlayFinishConfetti()
    {
        confetties.Play();
    }
}
