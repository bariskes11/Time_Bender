using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMousePositionTracker : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    private float depth = 5;
    [SerializeField]
    float movespeed = .1F;
    [SerializeField]
    LayerMask layerMask;


    #endregion
    

    #region Fields
    MeshRenderer[] mesh;
    Ray ray;
    RaycastHit raycastHit;
    Camera gameCam;
    Vector3 beginPos;
    Vector3 deltaPos;
    float initialzPos;
    bool movingToInitialPos;
    #endregion
    #region Properties
    private bool isEnabled;
    public bool IsEnabled
    {
        get => this.isEnabled;
        set
        {
            isEnabled = value;
            setMeshListStatus(isEnabled);
            if (this.isEnabled)
            {
                EventManager.OnPlayerStartControl.Invoke();
            }

        }
    }
    #endregion


    void Start()
    {
        this.mesh = this.GetComponentsInChildren<MeshRenderer>();
        gameCam = Camera.main;
        initialzPos = this.transform.position.z;
        beginPos = this.transform.position;
        setMeshListStatus(isEnabled);

    }

    
    // Update is called once per frame
    void Update()
    {
        if (!isEnabled)
            return;

        if (Input.GetMouseButton(0))
        {
            ray = gameCam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            if (Physics.Raycast(ray, out  raycastHit,Mathf.Infinity, this.layerMask))
            {
                this.transform.position = new Vector3(raycastHit.point.x, raycastHit.point.y + depth, raycastHit.point.z); //raycastHit.point;
            }
        }
        else
        {
          this.transform.position = Vector3.MoveTowards(this.transform.position, this.beginPos, movespeed);
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    this.beginPos = GetMouseCameraPoint();
        //    this.transform.position = this.beginPos;
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    deltaPos = this.beginPos - GetMouseCameraPoint();
        //    this.transform.position = deltaPos*Time.deltaTime;
        //}

    }

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.black;
        Gizmos.DrawWireSphere(this.raycastHit.point, 1F);

    }

    #region Private Methods

    void setMeshListStatus(bool stats)
    {
        foreach (var item in mesh)
        {
            item.enabled = stats;
        }
    }
    #endregion
}
