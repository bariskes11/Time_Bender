using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicHardCodeds;

public class StopMovementCollision : MonoBehaviour
{
    private Camera gameCam;
    private InteractionSystem human;
    private FpsRayCaster rayCaster;
    private void Start()
    {
        gameCam = Camera.main;
        human = GameObject.FindObjectOfType<InteractionSystem>();
        rayCaster = FindObjectOfType<FpsRayCaster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagNames.DangerObj.ToString()))
        {
            Debug.Log("triggered with danger obj");
            rayCaster.IsClicked = false;

            var obj = other.gameObject.GetComponent<ObjectControllerBase>();

            obj.IsControlstarted = false;
            obj.StopMovement();
            Destroy(obj.GetComponent<ObjectInteraction>());
            // set look rotation to player;
            gameCam.transform.DOLookAt(human.transform.position, .1F);

        }
    }
}
