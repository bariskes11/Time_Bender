using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    [SerializeField]
    bool changeAngleOnFinish = true;

    
    float mouseSensitivity=0.02F;
    [SerializeField]
    Camera camera;
    private float cameraPitch;
    private Vector3 lastPos;
    private Vector3 deltaPos;

    #region Properties
    private bool isControlEnabled;
    public bool IsControlEnabled
    {
        get => this.IsControlEnabled;
        set =>this.isControlEnabled = value;
    }
    private bool isMoving;
    public bool IsMoving
    {
        get => this.isMoving;
        set => this.isMoving = value;
    }
   
    #endregion

    #region Unity Methods


    void Start()
    {
        
        this.IsControlEnabled = false;
        EventManager.OnGameStarted.AddListener(this.EnableControls);
        EventManager.OnGameSuccess.AddListener(this.LookAtFinishPart);
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.isControlEnabled)
            return;

        Vector2 mouseMovement = MouseMovement();
        if (mouseMovement != Vector2.zero)
        {
            Vector3 dir = new Vector3((mouseMovement.y) * mouseSensitivity

                 , (-mouseMovement.x) * mouseSensitivity, 0);

            transform.localEulerAngles += dir;
            this.isMoving = true;
        }
        else
        {
            this.isMoving = false;
        }



        
    }

    public void LookAtTargetPoint(Vector3 pos)
    {
        Debug.Log($"Look At Target Point");
        this.isControlEnabled = false;
        // looks at final target point   
        Vector3 look = pos - this.transform.position;
        Quaternion lookr = Quaternion.LookRotation(look, Vector3.up);
        transform.DORotateQuaternion(lookr, .3F);


    }

    #endregion

    #region Private Methods

    void EnableControls()
    {
        this.isControlEnabled = true;
    }
    void LookAtFinishPart()
    {
        if (!changeAngleOnFinish)
            return;
        Vector3 finishPos = GameObject.FindObjectOfType<SuccesPoint>().transform.position;
        LookAtTargetPoint(finishPos);


    }


    Vector3 MouseMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            deltaPos = lastPos - Input.mousePosition;

            return deltaPos;
        }

        return Vector3.zero;
    }
    #endregion
}
