using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTargetPointMover : PlayerAnimController, IPlayParticle
{
    #region Unity Fields


    [SerializeField]
    Transform targetPosition;
    [SerializeField]
    ParticleSystem jumpParticle;
    [SerializeField]
    Transform jumpTargetPosition;
    [SerializeField]
    Transform finishTargetPosition;
    [SerializeField]
    Transform peoplePoint;
    [SerializeField]
    float timeOutForGetJump;
    [SerializeField]
    GameObject showmessage;
    #endregion

    #region Fields

    BuildingDropSystem buildingDropSystem;
    NewMousePositionTracker handControllerSystem;
    #endregion
    CameraSwitcher cameraSwitcher;


    protected override void Start()
    {
        base.Start();
        showmessage.gameObject.SetActive(false);
        buildingDropSystem = GameObject.FindObjectOfType<BuildingDropSystem>();
        handControllerSystem = GameObject.FindObjectOfType<NewMousePositionTracker>();
        if (!handControllerSystem)
        {
            Debug.Log("<color=red>There is no hand controller controls wont work</color>");

        }
        if (!buildingDropSystem)
        {
            Debug.Log("<color=red>There is no Dropped object in scene cutting system wont work</color>");
        }

        EventManager.OnGameStarted.AddListener(MoveTowardsTargetPoint);
        cameraSwitcher = GameObject.FindObjectOfType<CameraSwitcher>();
        if (!cameraSwitcher)
            Debug.Log("<color=red> There is No CameraSwitcher In Game cameras wont work</color>");

        EventManager.OnPlayerMoveToEndPoint.AddListener(SetPlayerFinishAnimation);
    }
    private void MoveTowardsTargetPoint()
    {
        this.transform.DOMove(targetPosition.position, 0.5F).OnComplete(SetIdleAnim);
        this.cameraSwitcher.SetCameraByIndex(1);
    }
    // this is animation event fired from character
    public void SetJumpEventAnim()
    {
        //main game play starts here
        this.transform.DOMove(jumpTargetPosition.position, 1.2F);
        this.handControllerSystem.IsEnabled = true;
        cameraSwitcher.SetCameraByIndex(2); // fps cam
        PlayParticle();
        buildingDropSystem?.StartToFall();
    }

    private void SetIdleAnim()
    {

        this.ChangeToIdleState();
        StartCoroutine(showGenerelStuationAndJumpUp());
        this.showmessage.gameObject.SetActive(true);

    }

    IEnumerator showGenerelStuationAndJumpUp()
    {
        
        cameraSwitcher.SetCameraByIndex(3);// people view Cam
        yield return new WaitForSeconds(1.4F);
        cameraSwitcher.SetCameraByIndex(4); // upersituation cam
        yield return new WaitForSeconds(1.6F);
        cameraSwitcher.SetCameraByIndex(1); //player cam 
        yield return new WaitForSeconds(0.6F);
        showmessage.gameObject.SetActive(false);
        this.ChangeToJumpState();
        yield return null;
    }

    public void PlayParticle()
    {
        jumpParticle.Play();
    }

    void SetPlayerFinishAnimation()
    {
        StartCoroutine(switchFinishCamCoroutine());
    }

    IEnumerator switchFinishCamCoroutine()
    {
        this.cameraSwitcher.SetCameraByIndex(5);
        yield return new WaitForSeconds(2F);
        this.ChangeToLandingState();
        this.transform.DOLookAt(this.finishTargetPosition.position, .5F, AxisConstraint.Y);
        this.transform.DOMove(this.finishTargetPosition.position, .5F).OnComplete(LookAtPeopleAround);
        // disableplane and show how many humans are dead
        // make breakable object quickly fall down by changing angular drag
    }

    void LookAtPeopleAround()
    {
        this.cameraSwitcher.SetCameraByEnum(PublicHardCodeds.CurrentCamera.FinalStatusCamera);
        this.transform.DOLookAt(this.peoplePoint.position, 0.5F, AxisConstraint.Y);
        //dropitems from above

        StartCoroutine(setRigidBodyAngularDrag());

    }

    IEnumerator setRigidBodyAngularDrag()
    {
        yield return new WaitForSeconds(1F);
        var obj = GameObject.FindObjectsOfType<CutCalculator>();
        foreach (var item in obj)
        {
            item.GetComponent<Rigidbody>().drag = 0F;
            item.GetComponent<Rigidbody>().angularDrag = 0F;
        }

        EventManager.OnStartCountDown.Invoke();
    }




}
