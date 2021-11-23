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
    #endregion

    #region Unity Methods
    private void Start()
    {
        mainCam = Camera.main;
        allInteractables = FindObjectsOfType<MonoBehaviour>().OfType<IInteractable>().ToArray();
    }

    private void Update()
    {
        ray = mainCam.ViewportPointToRay(new Vector3(.5F, .5F, 0));//center of screen
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayers))
        {
            hit.transform.GetComponentInChildren<IInteractable>().Interact();
            //show slowdown  and fasterButton
        }
        else
        {
            // noting hit back to normal

            foreach (var item in allInteractables)
            {
                item.NonInteract();
            }
        }

    }
    #endregion

}
