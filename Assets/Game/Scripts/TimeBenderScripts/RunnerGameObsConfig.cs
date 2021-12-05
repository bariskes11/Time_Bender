using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RunnerGameObsConfig : MonoBehaviour
{
    [SerializeField]
    bool isTriggerActivated;
    private void Start()
    {
        EventManager.OnGameStarted.AddListener(this.SetObstacles);
    }

    private void SetObstacles()
    {
        var list = GameObject.FindObjectsOfType<ObjectControllerBase>().ToList();
        foreach (var item in list)
        {
            Debug.Log($"Setting Item Trigger {item}", item.gameObject);
            item.IsEnabledOnTrigger = true;
        }
    }
}
