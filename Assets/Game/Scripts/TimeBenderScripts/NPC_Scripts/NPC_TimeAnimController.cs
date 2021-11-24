using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NPC_TimeAnimController : MonoBehaviour
{
    #region Fields
    Animator anims;
    #endregion
    private void Start()
    {
        anims = this.GetComponent<Animator>();
        anims.speed = 0;
        EventManager.OnGameStarted.AddListener(this.StartAnimations);
        EventManager.OnFasterButtonPressed.AddListener(this.SetFasterAnimation);
        EventManager.OnSlowDownButtonPressed.AddListener(this.setSlowerAnimation);
    }

    void StartAnimations()
    {
        anims.speed = 1;
    }

    void SetFasterAnimation()
    {
        anims.speed = .5F;
    }
    void setSlowerAnimation()
    {
        anims.speed = 2F;
    }


}
