using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicEnums;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class InteractionSystem : MonoBehaviour, IInteractable
{
    #region Unity Fields
    [SerializeField]
    Material interactionMaterial;
    [SerializeField]
    Material fasterMaterial;
    [SerializeField]
    Material slowerMaterial;

    [SerializeField]
    GameObject buttonPanel;
    #endregion
    #region Fields
    Material defaultMaterial;
    SkinnedMeshRenderer currentRenderer;
    bool isSpeedChanged=false; // is object's speed changed
    public bool IsAimed { get; set; }

    #endregion



    #region Unity Methods
    protected virtual void Start()
    {
        
        currentRenderer = this.GetComponent<SkinnedMeshRenderer>();
        buttonPanel.gameObject.SetActive(false);
        defaultMaterial = currentRenderer.material;
        EventManager.OnGameSuccess.AddListener(this.SetDefaultmaterial);
        this.IsAimed = false;


    }
    #endregion


    public void Interact(CurrentMode mod)
    {
        this.IsAimed = true;
        setMaterialBasedOnMode(mod);
        buttonPanel.gameObject.SetActive(true);
        
    }

    public void NonInteract()
    {
        this.IsAimed = false;
        if (isSpeedChanged)
            return;
        currentRenderer.material = defaultMaterial;
        if(buttonPanel!=null)
        buttonPanel.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    #region Private Methods
    void setMaterialBasedOnMode(CurrentMode mode)
    {
        switch (mode)
        {
            case CurrentMode.Normal:
                currentRenderer.material = interactionMaterial;
                break;
            case CurrentMode.Faster:
                currentRenderer.material = fasterMaterial;
                this.isSpeedChanged = true;
                break;
            case CurrentMode.Slower:
                currentRenderer.material = slowerMaterial;
                this.isSpeedChanged = true;
                break;
            
            default:
                break;
        }
    }

    void SetDefaultmaterial()
    {
        currentRenderer.material = defaultMaterial;
    }


    #endregion

}
