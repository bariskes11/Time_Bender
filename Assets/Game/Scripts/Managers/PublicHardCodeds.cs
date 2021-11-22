using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PublicHardCodeds
{
    public enum GameStats
    {
        TapToPlay,
        Win,
        Lose,
        InGame
    }
    public enum PlayerAnimationParameters
    {
        RunState, // default state
        JumpState,
        JumpDownState,
        VictoryState,
        IdleState,
        FailState
    }
    public enum TagNames
    { 
    BreakableObject
    }
    public enum CurrentCamera
    {
        PlayerCam = 1,
        FPSCam = 2,
        PeopleViewCam = 3,
        UpperStuationCam = 4,
        FinishCamera = 5,
        FinalStatusCamera = 6
    }
}
