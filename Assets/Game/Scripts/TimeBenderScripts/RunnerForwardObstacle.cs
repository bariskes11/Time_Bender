using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerForwardObstacle : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    Vector3 objectOffset= new Vector3(0,0,3);
    #endregion

    #region Fields
    NPC_MovementController NPC_player;
    Vector3 currentPlayerPos;
    #endregion
    #region Unity Methods
    private void Start()
    {
        NPC_player= GameObject.FindObjectOfType<NPC_MovementController>();
        if (NPC_player == null)
            Debug.Log("<color=red> There is no NPC player game won't work  </color>");
    }
    private void Update()
    {
        currentPlayerPos = NPC_player.transform.position + objectOffset;
        this.transform.position = currentPlayerPos;
    }

    #endregion
}
