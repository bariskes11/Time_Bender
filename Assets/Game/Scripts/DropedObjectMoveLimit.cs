using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedObjectMoveLimit : MonoBehaviour
{


    #region Unity Methods
    private void Start()
    {
        EventManager.OnPlayerMoveToEndPoint.AddListener(this.DestroyThisGameObject);
        
    }
    #endregion
    #region Private Methods
    void DestroyThisGameObject()
    {
        Destroy(this.gameObject);
    }
    #endregion


}
