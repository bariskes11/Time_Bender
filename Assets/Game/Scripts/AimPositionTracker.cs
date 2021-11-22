using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPositionTracker : MonoBehaviour
{
    #region Unity Fields

    [SerializeField]
    float trackspeed;
    [SerializeField]
    Transform positionToFollow;
    [SerializeField]
    float yOffset;
    [SerializeField]
    float zOffset;
    [SerializeField]
    float xOffset;
    #endregion

    #region Unity Methods
    private void Start()
    {
        this.gameObject.SetActive(false);
        EventManager.OnPlayerStartControl.AddListener(this.ActivateGameObject);
    }

    void Update()
    {
        if (!positionToFollow)
            return;

        this.transform.position = Vector3.MoveTowards(this.transform.position, positionToFollow.position, trackspeed);
        var lookPos = positionToFollow.position - transform.position;
        var rotation = Quaternion.LookRotation(lookPos);
        rotation.z += zOffset;
        rotation.y += yOffset;
        rotation.x += xOffset;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10F);


    }
    #endregion
    #region Private Methods
    void ActivateGameObject()
    {
        this.gameObject.SetActive(true);
    }
    #endregion
    // Update is called once per frame

}
