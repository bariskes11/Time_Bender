using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SineDeformer))]
public class StaffChangerScript : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    float meshdeform_animSpeed;
    [SerializeField]
    float mneshdeform_Frequency;
    [SerializeField]
    GameObject normalmodeStaff;


    [SerializeField]
    GameObject fasterModeStaff;
    [SerializeField]
    GameObject slowerModeStaff;
    #endregion

    #region Fields

    SineDeformer sindeform;
    #endregion

    #region Unity Methods

    private void Start()
    {
        EventManager.OnFasterButtonPressed.AddListener(setFastMode);
        EventManager.OnSlowDownButtonPressed.AddListener(setSlowMode);
    }


    #endregion
    #region Private Methods
    private void setSlowMode()
    {
        StartCoroutine(setSlowModeCoroutine());
    }
    private void setFastMode()
    {
    }
    IEnumerator setSlowModeCoroutine()
    {

        yield return new WaitForSeconds(.1F);
    }
    #endregion


}
