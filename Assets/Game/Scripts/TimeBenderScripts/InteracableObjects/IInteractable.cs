using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicEnums;

public interface IInteractable 
{
    public bool IsAimed { get; set; }
    void Interact(CurrentMode mode);
    void NonInteract();

    void RemoveInteract();
}
