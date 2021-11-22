using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    #region Unirt Fields


    [SerializeField]
    Image timeFillImage;
    [SerializeField]
    TextMeshProUGUI txt_breakCount;
    [SerializeField]
    float distanceForSaveTheDay;
    

    #endregion

    #region Fields

    BuildingDropSystem currentBuildingPosition;
    DropedObjectMoveLimit droppedObjectMovePoint;
    float currentDistanceLeft;
    float initialDistance;
    float currentDistance;
    #endregion
    #region Properties
    private bool isCuttingObject;
    public bool IsCuttingObject
    {
        get => this.isCuttingObject;
        set => isCuttingObject = value;
    }

    private int currentCutCount;
    public int CurrentCutCount
    {
        get => this.currentCutCount;
        set => this.currentCutCount = value;
    }


    #endregion
    #region Unity Methods

    private void Start()
    {
        
        this.IsCuttingObject = true;
        currentBuildingPosition = GameObject.FindObjectOfType<BuildingDropSystem>();
        droppedObjectMovePoint = GameObject.FindObjectOfType<DropedObjectMoveLimit>();
        if (!currentBuildingPosition)
            Debug.Log("<color=red>There is no Building Drop System system Wont work</color>");
        currentCutCount = 0;
        this.currentDistanceLeft = distanceForSaveTheDay;
        if (!timeFillImage)
            Debug.Log("<color=red>There is no Image to Fill Time wont Work!!</color>");
        if (!txt_breakCount)
            Debug.Log("<color=red>There is no BreakCountert Counting system Won't Work!!</color>");
        Vector3 dist = (currentBuildingPosition.transform.position-droppedObjectMovePoint.transform.position );
        this.initialDistance = dist.y;
        timeFillImage.fillAmount = 1;
    }

    private void Update()
    {

        if (!isCuttingObject)
            return;
        Vector3 dist = (currentBuildingPosition.transform.position - droppedObjectMovePoint.transform.position);
        this.timeFillImage.fillAmount =dist.y/initialDistance;
     //   Debug.Log($"Current Distance  {dist.y}, Initialdistance {initialDistance}");
        if (this.timeFillImage.fillAmount <= 0.05F)
        {
            this.isCuttingObject = false;
            //setplayer for destination Point3 and finish ghame play
            EventManager.OnPlayerMoveToEndPoint.Invoke();
        }
    }
    #endregion
}
