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



    #endregion
    #region Fields
    GameObject buttonPanel;
    Material defaultMaterial;
    bool canInteract;
    SkinnedMeshRenderer currentRenderer;
    bool isSpeedChanged = false; // is object's speed changed
    public bool IsAimed { get; set; }


    #endregion
    #region Properties
    public CurrentMode CurrentMode {get;private set;}
    #endregion



    #region Unity Methods
    protected virtual void Start()
    {
        this.canInteract = true;   
        currentRenderer = this.GetComponent<SkinnedMeshRenderer>();
        
        EventManager.OnGameStarted.AddListener(this.SetButtonPanel);
        defaultMaterial = currentRenderer.material;
        EventManager.OnGameSuccess.AddListener(this.SetDefaultmaterial);
        this.IsAimed = false;


    }
    #endregion


    public void Interact(CurrentMode mod)
    {
        if (!this.canInteract) return;
        this.CurrentMode = mod;
        this.IsAimed = true;
        setMaterialBasedOnMode(mod);
        if (buttonPanel == null) return;
        buttonPanel.gameObject.SetActive(true);
        
    }

    public void NonInteract()
    {
        if (!this.canInteract) return;
        this.IsAimed = false;
        if (isSpeedChanged)
            return;
        currentRenderer.material = defaultMaterial;
        if(buttonPanel!=null)
        buttonPanel.gameObject.SetActive(false);
    }

    public void RemoveInteract()
    {
        currentRenderer.material = defaultMaterial;
        this.canInteract = false;
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
    void SetButtonPanel()
    {
        buttonPanel = FindObjectOfType<ButtonBehaviours>(true).gameObject;
        if (buttonPanel == null)
            Debug.Log("<color=red>There is no Button Panel in game !!</color>");
        buttonPanel.gameObject.SetActive(false); 
    }


    #endregion

}
