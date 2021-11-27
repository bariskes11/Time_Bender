using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FpsRayCaster : MonoBehaviour
{

    #region Unity Fields
    [SerializeField]
    LayerMask raycastLayers;
    #endregion
    #region Fields
    Camera mainCam;
    Ray ray;
    RaycastHit hit;
    IInteractable[] allInteractables;
    GameObject cachedSlowLine;
    GameObject cachedFastLine;
    GameObject currentLine;
    GameObject lastInteractionPoint;
    bool isClicked;

    #endregion
    #region Properties
    private bool isFocused;
    public bool IsFocused
    {
        get => this.isFocused;
        set => this.isFocused = value;
    }


    #endregion



    #region Unity Methods
    private void Start()
    {
        mainCam = Camera.main;
        allInteractables = FindObjectsOfType<MonoBehaviour>().OfType<IInteractable>().ToArray();
        EventManager.OnFasterButtonPressed.AddListener(this.StartFollowingLastPoint);
        EventManager.OnSlowDownButtonPressed.AddListener(this.StartFollowingLastPoint);
        EventManager.OnGameSuccess.AddListener(this.DisableRaycast);
        this.isClicked = false;



    }
    

    private void Update()
    {
        if (isClicked)
        {
            this.transform.LookAt(this.lastInteractionPoint.transform);
            return;
        }
        ray = mainCam.ViewportPointToRay(new Vector3(.5F, .5F, 0));//center of screen
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayers))
        {
            var rslt = hit.transform.GetComponentInChildren<IInteractable>();
            if (rslt != null)
            {
                this.lastInteractionPoint = hit.transform.gameObject;
                rslt.Interact();
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
        this.isClicked = true;
    }
    void DisableRaycast()
    {

        foreach (var item in allInteractables)
        {
            item.NonInteract();
            item.IsAimed = false;
            this.IsFocused = false;
        }
    }
    #endregion
}
