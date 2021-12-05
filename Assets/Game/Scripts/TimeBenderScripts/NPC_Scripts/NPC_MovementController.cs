using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicHardCodeds;

public class NPC_MovementController : NPC_Base
{
    [SerializeField]
    float normalRunSpeed;
    [SerializeField]
    [Header("This value can be *2 or /2")]
    float sloworFasterSpeedMultiply;
    
    
    [SerializeField]
    GameObject chrushParticle;

    #region Fields
    Transform targetPosition;

    bool isStarted;

    #endregion
    #region Properties

    GameObject cachedchrusParticle;
    #endregion
    #region Properties
    private float currentSpeed;
    public float CurrentSpeed
    {
        get => this.currentSpeed;
        set => this.currentSpeed = value;
    }
    #endregion
    protected override void Start()
    {
        base.Start();
        targetPosition = GameObject.FindObjectOfType<SuccesPoint>().transform;
        if (!targetPosition) {
            Debug.Log($"<color=red>There is No SuccesPoint in game player won't run!!</color>");
        }
        currentSpeed = normalRunSpeed;
        EventManager.OnFasterButtonPressed.AddListener(this.SetFasterSpeed);
        EventManager.OnSlowDownButtonPressed.AddListener(this.SetSlowDownSpeed);
        EventManager.OnGameFail.AddListener(this.DisableControls);
        EventManager.OnGameSuccess.AddListener(this.LookAtCamera);
        cachedchrusParticle = Instantiate(chrushParticle);
    }
    protected override void SetSlowDownSpeed()
    {
        base.SetSlowDownSpeed();
        if (interaction.IsAimed)
            currentSpeed = normalRunSpeed / sloworFasterSpeedMultiply;
    }
    protected override void SetFasterSpeed()
    {
        base.SetFasterSpeed();
        if (interaction.IsAimed)
            currentSpeed = normalRunSpeed * sloworFasterSpeedMultiply;

    }
    protected override void SetStartStatus()
    {
        base.SetStartStatus();
        currentSpeed = normalRunSpeed;
    }
    protected override void Update()
    {
        base.Update();
        if (!this.iscontrolstarted)
            return;
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition.position, currentSpeed * Time.deltaTime);
        this.transform.LookAt(targetPosition.position);
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag(TagNames.DangerObj.ToString()))
        {
            Debug.Log($"This Object is Collided with {other.gameObject}", other.gameObject);
            Vector3 hitPoint = other.gameObject.GetComponent<Collider>().ClosestPoint(transform.position);
            cachedchrusParticle.transform.position = hitPoint;
            cachedchrusParticle.GetComponent<ParticleSystem>().Play();
        }
    }
    void DisableControls()
    {
        this.iscontrolstarted = false;
    }
    void LookAtCamera()
    {
        this.iscontrolstarted = false;
        this.transform.LookAt(Camera.main.transform.position);
    }

}
