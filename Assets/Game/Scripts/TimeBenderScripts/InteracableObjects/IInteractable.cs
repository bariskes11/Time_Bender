using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public bool IsAimed { get; set; }
    void Interact();
    void NonInteract();
}
