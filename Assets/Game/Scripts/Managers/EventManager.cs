using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    public static UnityEvent OnGameStarted = new UnityEvent();
    public static UnityEvent OnGameSuccess = new UnityEvent();
    public static UnityEvent OnGameFail = new UnityEvent();
    public static UnityEvent OnSliced = new UnityEvent();
    public static UnityEvent OnPlayerMoveToEndPoint = new UnityEvent();
    public static UnityEvent OnPlayerStartControl = new UnityEvent();
    public static UnityEvent OnStartCountDown = new UnityEvent();
    public static UnityEvent OnPersonDied = new UnityEvent();
}
