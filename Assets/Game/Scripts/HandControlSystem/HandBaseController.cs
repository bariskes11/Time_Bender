using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBaseController : MonoBehaviour
{

    [SerializeField]
    Vector3 weaponOffset;
    [SerializeField]
    float moveSpeed;



    Transform initialPos;
    MouseDeltaTracker mouseTracker = new MouseDeltaTracker();
    Vector3 movePos = Vector3.zero;
    Ray ray;
    #region Properties
    protected bool isInControl = false;
    public bool IsInControl
    {
        get => this.isInControl;
        set => this.isInControl = value;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        initialPos = this.transform;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 movePos = mouseTracker.GetDelta();
        Debug.Log($"Mouse Current Delta  {movePos}  objects current Position {this.transform.position}", this.gameObject);

        this.transform.position += new Vector3(movePos.x, 0, movePos.y) * moveSpeed * Time.deltaTime;
        if (isInControl)
        {


            //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity) && Input.GetMouseButton(0))
            //{
            //    var offset = this.weaponOffset;
            //    this.transform.position = hit.point + offset;
            //    Debug.DrawRay(ray.origin, ray.direction * 20, Color.green);
            //}

        }
        if (Input.GetMouseButtonUp(0))
        {
            //this.isInControl = false;
            Debug.Log("Backto Position");
            BackToInitialPosition();
        }
    }

    void BackToInitialPosition()
    {
        this.transform.DOMove(initialPos.position, 0.5F);
        this.transform.DORotateQuaternion(initialPos.rotation, 0.5F);

    }

}
