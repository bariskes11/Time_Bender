using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NPC_TimeAnimController : NPC_Base
{
    #region Fields
    Animator anims;
    #endregion
    protected override void Start()
    {
        base.Start();
        anims = this.GetComponent<Animator>();
        anims.speed = 0;

    }

    protected override void SetStartStatus()
    {
        base.SetStartStatus();

        anims.speed = 1;
    }

    protected override void SetFasterSpeed()
    {
        base.SetFasterSpeed();
        if (interaction.IsAimed)
            anims.speed = 2F;
    }
    protected override void SetSlowDownSpeed()
    {
        base.SetSlowDownSpeed();
        if (interaction.IsAimed)
            anims.speed = .5F;
    }

    public void PlayVictoryAnim()
    {
        anims.speed = 1;
        anims.SetBool("Happy", true);

    }


}
