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
    #region Unity Methods
    private void Start()
    {
        
        currentRenderer = this.GetComponent<SkinnedMeshRenderer>();
        defaultMaterial = currentRenderer.material;

    }
    #endregion


    public void Interact()
    {
        currentRenderer.material = interactionMaterial;
    }

    public void NonInteract()
    {
        currentRenderer.material = defaultMaterial;
    }
    // Start is called before the first frame update

}
