using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    List<Animator> playerAnimators;
    
    protected virtual void Start()
    {
        this.setAnimators();   
    }

    void setAnimators()
    {
        if ( playerAnimators==null || playerAnimators.Count == 0)
        {
            playerAnimators = this.GetComponentsInChildren<Animator>().ToList();
            if (playerAnimators.Count < 2)
            {
                Debug.Log("<color=red>Player Should have Two Animators Animations Wont Work</color>");
            }
        }
    }

    [ContextMenu("SetJumpState")]
    protected void ChangeToJumpState()
    {
        
        this.setAnimators();
        foreach (var item in playerAnimators)
        {
            item.SetBool(PublicHardCodeds.PlayerAnimationParameters.JumpState.ToString(), true);
        }
    }

    [ContextMenu("SetIdleState")]
    protected void ChangeToIdleState()
    {
        this.setAnimators();
        foreach (var item in playerAnimators)
        {
            item.SetBool(PublicHardCodeds.PlayerAnimationParameters.IdleState.ToString(), true);
        }
    }


    [ContextMenu("SetLandingState")]
    protected void ChangeToLandingState()
    {
        this.setAnimators();
        foreach (var item in playerAnimators)
        {
            item.SetBool(PublicHardCodeds.PlayerAnimationParameters.JumpDownState.ToString(), true);
        }
    }

    [ContextMenu("SetVictoryState")]
    public void ChangeToVictoryState()
    {
        this.setAnimators();
        foreach (var item in playerAnimators)
        {
            item.SetBool(PublicHardCodeds.PlayerAnimationParameters.VictoryState.ToString(), true);
        }
    }
    [ContextMenu("SetFailState")]
    public void ChangeToFailState()
    {
        this.setAnimators();
        foreach (var item in playerAnimators)
        {
            item.SetBool(PublicHardCodeds.PlayerAnimationParameters.FailState.ToString(), true);
        }
    }


}
