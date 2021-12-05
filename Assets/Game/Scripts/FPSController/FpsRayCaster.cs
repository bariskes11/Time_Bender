using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static PublicEnums;

[RequireComponent(typeof(FpsController))]
public class FpsRayCaster : MonoBehaviour
{

    #region Unity Fields
    [SerializeField]
    LayerMask raycastLayers;
    [SerializeField]
    GameObject hiPointObject;

    [SerializeField]
    bool isFollowingTarget=true;
    #endregion
    #region Fields
    Camera mainCam;
    Ray ray;
    RaycastHit hit;
    IInteractable[] allInteractables;
    //GameObject cachedSlowLine;
    //GameObject cachedFastLine;
    GameObject currentLine;
    GameObject lastInteractionPoint;
    
    GameObject currenthitPointObject;
    FpsController fpsController;
    CurrentMode currentMode;
    bool isSystemEnabled;
    #endregion
    #region Properties
    private bool isFocused;
    public bool IsFocused
    {
        get => this.isFocused;
        set => this.isFocused = value;
    }
    private bool isClicked;
    public bool IsClicked
    {
        get => this.isClicked;
        set => this.isClicked = value;
    }


    #endregion



    #region Unity Methods
    private void Start()
    {
        isSystemEnabled = true;
        currenthitPointObject = Instantiate( this.hiPointObject);
        mainCam = Camera.main;
        allInteractables = FindObjectsOfType<MonoBehaviour>().OfType<IInteractable>().ToArray();
        fpsController = this.GetComponent<FpsController>();
        EventManager.OnFasterButtonPressed.AddListener(this.SetFastMode);
        EventManager.OnSlowDownButtonPressed.AddListener(this.SetSlowMode);
        EventManager.OnGameSuccess.AddListener(this.DisableRaycast);


    }

    

    private void Update()
    {
        if (!isSystemEnabled) return;
        if (fpsController.IsMoving)
        {
            this.lastInteractionPoint = null;
        }
        if (!fpsController.IsMoving && this.lastInteractionPoint!=null && this.isFollowingTarget)
        {
        
            
            this.transform.LookAt(this.lastInteractionPoint.transform);
        }


        ray = mainCam.ViewportPointToRay(new Vector3(.5F, .5F, 0));//center of screen
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayers))
        {
            var rslt = hit.transform.GetComponentInChildren<IInteractable>();
            if (rslt != null)
            {
                
                currenthitPointObject.transform.SetParent(hit.transform);
                currenthitPointObject.transform.position = hit.point;
                this.lastInteractionPoint = currenthitPointObject;
                Debug.Log($"Current Mode {this.currentMode}");
                rslt.Interact(this.currentMode);
                rslt.IsAimed = true;
                this.IsFocused = true;
                
            }
            if (currentLine != null)
            {
                currentLine.transform.position = hit.point;
            }

            //show slowdown  and fasterButton
        }
        else
        {
            
            if (allInteractables==null) return;
            // noting hit back to normal
            foreach (var item in allInteractables)
            {
                item.NonInteract();
                item.IsAimed = false;
                this.IsFocused = false;
            }
        }

    }
 
    #endregion

    #region Private Methods
    void StartFollowingLastPoint()
    {
        
        
    }
    void SetFastMode()
    {
        this.isClicked = true;
        this.currentMode = CurrentMode.Faster;
    }
    void SetSlowMode()
    {
        this.isClicked = true;
        this.currentMode = CurrentMode.Slower;
    }
    void DisableRaycast()
    {
        isSystemEnabled = false;
        foreach (var item in allInteractables)
        {
            item.NonInteract();
            item.IsAimed = false;
            this.IsFocused = false;
        }

    }
    #endregion
    #region Private Methods

    #endregion

}
