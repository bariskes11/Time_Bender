using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static PublicHardCodeds;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    List<CinemachineVirtualCamera> cameraList = new List<CinemachineVirtualCamera>();

    private void Start()
    {
        if (cameraList.Count == 0)
            Debug.Log("Cameras Arent Set!");
        cameraList = cameraList.OrderBy(x => x.Name).ToList();
        this.SetCameraByIndex(1);
    }

    /// <summary>
    /// 1_PlayerCam
    /// 2_FPSCam
    /// 3_PeopleViewCam
    /// 4_UpperStuaitonCam
    /// 5_FinishCamera
    /// 6_FinalStatusCamera
    /// </summary>
    /// <param name="Index"></param>
    
   public void SetCameraByIndex(int Index)
    {
     var currentCam=cameraList.Where(x => x.gameObject.name.Contains(Index.ToString())).FirstOrDefault();

        foreach (var item in cameraList)
        {
            item.Priority = 0;
        }
        currentCam.Priority = 1;
    }

    public void SetCameraByEnum(CurrentCamera camera)
    {
        var currentCam = cameraList.Where(x => x.gameObject.name.Contains(camera.ToString())).FirstOrDefault();
        foreach (var item in cameraList)
        {
            item.Priority = 0;
        }
        currentCam.Priority = 1;
    }



}
