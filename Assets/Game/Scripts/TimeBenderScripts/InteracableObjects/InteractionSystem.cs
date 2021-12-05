using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicEnums;



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
    MeshRenderer currentRenderer;
    SkinnedMeshRenderer skinnedMeshRenderer;
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
        currentRenderer = this.GetComponent<MeshRenderer>();


        
        EventManager.OnGameStarted.AddListener(this.SetButtonPanel);
        if (currentRenderer != null)
        {
            defaultMaterial = currentRenderer.material;
        }
        else
        {
            skinnedMeshRenderer = this.GetComponent<SkinnedMeshRenderer>();
            defaultMaterial = skinnedMeshRenderer.material;

        }
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

        ChangeMaterial(defaultMaterial);
        if(buttonPanel!=null)
        buttonPanel.gameObject.SetActive(false);
    }

    public void RemoveInteract()
    {

        ChangeMaterial(defaultMaterial);
        this.canInteract = false;
    }
    // Start is called before the first frame update
    #region Private Methods
    void setMaterialBasedOnMode(CurrentMode mode)
    {
        switch (mode)
        {
            case CurrentMode.Normal:
                ChangeMaterial(interactionMaterial);
                
                break;
            case CurrentMode.Faster:
                ChangeMaterial(fasterMaterial);
                this.isSpeedChanged = true;
                break;
            case CurrentMode.Slower:
                ChangeMaterial(slowerMaterial);
                this.isSpeedChanged = true;
                break;
            
            default:
                break;
        }
    }
    void ChangeMaterial(Material mat)
    {
        if (currentRenderer != null)
            currentRenderer.material = mat;
        else if (skinnedMeshRenderer != null)
            skinnedMeshRenderer.material = mat;
    }

    void SetDefaultmaterial()
    {
        ChangeMaterial(defaultMaterial);
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
