using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class InteractionSystem : MonoBehaviour, IInteractable
{
    #region Unity Fields
    [SerializeField]
    Material interactionMaterial;
    [SerializeField]
    GameObject buttonPanel;
    #endregion
    #region Fields
    Material defaultMaterial;
    SkinnedMeshRenderer currentRenderer;
    public bool IsAimed { get; set; }
    #endregion



    #region Unity Methods
    protected virtual void Start()
    {
        
        currentRenderer = this.GetComponent<SkinnedMeshRenderer>();
        buttonPanel.gameObject.SetActive(false);
        defaultMaterial = currentRenderer.material;

    }
    #endregion


    public void Interact()
    {
        currentRenderer.material = interactionMaterial;
        buttonPanel.gameObject.SetActive(true);

    }

    public void NonInteract()
    {
        currentRenderer.material = defaultMaterial;
        if(buttonPanel!=null)
        buttonPanel.gameObject.SetActive(false);
    }
    // Start is called before the first frame update

}
