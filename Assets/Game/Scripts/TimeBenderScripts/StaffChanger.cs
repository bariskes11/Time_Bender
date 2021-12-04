using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicEnums;

public class StaffChanger : MonoBehaviour
{
    #region Unity Fields
    [Header("Normal Staff Change Animation parameters")]
    [SerializeField]
    float animSpeed;
    [SerializeField]
    float freaquencySpeed;
    [SerializeField]
    [Range(0.0001F, 2F)]
    float timeoutperIteration = .1F;

    [SerializeField]
    [Range(0.0001F, 4F)]
    float changevalluePerIteration = .1F;

    [Header("--------------")]
    [SerializeField]
    GameObject normalModeStaff;
    [SerializeField]
    GameObject fasterModeStaff;
    [SerializeField]
    GameObject slowerModeStaff;
    #endregion

    #region Fields
    SineDeformer sindeform;
    #endregion
    #region Events

    
    #endregion


    #region Properties
    private bool isChanged;
    public bool IsChanged
    {
        get => this.isChanged;
        set => this.isChanged = value;

    }


    #endregion

    #region Unity Methods

    private void Start()
    {
        EventManager.OnFasterButtonPressed.AddListener(this.SetFastMode);
        EventManager.OnSlowDownButtonPressed.AddListener(this.SetSlowMode);
        sindeform = normalModeStaff.GetComponent<SineDeformer>();
        isChanged = false;
        
    }


    #endregion
    #region Private Methods
    private void SetSlowMode()
    {
        //if (isChanged)
        //    return;


        StartCoroutine(SetAnimAndMode(this.slowerModeStaff));
        isChanged = true;
    }
    private void SetFastMode()
    {
        //if (isChanged)
        //    return;
        

        StartCoroutine(SetAnimAndMode(this.fasterModeStaff));
        isChanged = true;
    }
    IEnumerator SetAnimAndMode(GameObject objectToShow)
    {
        setAnimation();
        while (sindeform.AnimationSpeed < this.animSpeed
            || sindeform.Frequency < this.freaquencySpeed
            )
        {
            yield return new WaitForSeconds(timeoutperIteration);
            if (sindeform.AnimationSpeed < this.animSpeed)
                sindeform.AnimationSpeed += changevalluePerIteration;
            if (sindeform.Frequency < this.freaquencySpeed)
                sindeform.Frequency += changevalluePerIteration;
        }
        GameObject g = Instantiate(objectToShow);
        g.transform.SetParent(this.transform);
        g.transform.localPosition = Vector3.zero;
        g.transform.localScale = Vector3.one * .5F;
        g.transform.localRotation = Quaternion.identity;
       GameObject objtodestroy=  this.GetComponentInChildren<LaserManager>().gameObject;
        Destroy(objtodestroy);
        sindeform = g.GetComponent<SineDeformer>();
        sindeform.AnimationSpeed = this.animSpeed;
        sindeform.Frequency = this.freaquencySpeed;

        while (sindeform.AnimationSpeed > 0F
            || sindeform.Frequency > 0F
            )
        {
            yield return new WaitForSeconds(timeoutperIteration);
            if (sindeform.AnimationSpeed > 0)
                sindeform.AnimationSpeed -= changevalluePerIteration;
            if (sindeform.Frequency > 0)
                sindeform.Frequency -= changevalluePerIteration;
        }
    }

    void setAnimation()
        {
        sindeform.gameObject.GetComponent<Animator>().SetTrigger("Hit");
    }
    #endregion


}
