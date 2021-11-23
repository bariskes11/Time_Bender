using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class HumanInteracton : MonoBehaviour, IInteractable
{
    #region Unity Fields
    [SerializeField]
    Material interactionMaterial;
    #endregion
    #region Fields
    Material defaultMaterial;
    SkinnedMeshRenderer currentRenderer;

    #endregion
    #region Properties

    private bool isInInteraction;
    public bool IsInInteraction
    {
        get => this.isInInteraction;
        set => this.isInInteraction = value;    
    }
    #endregion


    #region Unity Methods
    protected  virtual void Start()
    {
        
        currentRenderer = this.GetComponent<SkinnedMeshRenderer>();
        defaultMaterial = currentRenderer.material;

    }
    #endregion


    public void Interact()
    {
        currentRenderer.material = interactionMaterial;
        isInInteraction = true;
    }

    public void NonInteract()
    {
        currentRenderer.material = defaultMaterial;
        isInInteraction = false;
    }
    // Start is called before the first frame update

}
