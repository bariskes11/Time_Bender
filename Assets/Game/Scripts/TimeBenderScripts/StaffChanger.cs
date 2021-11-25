using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StaffChanger : MonoBehaviour
{
    #region Unity Fields
    [Header("Normal Staff Change Animation parameters")]
    [SerializeField]
    float animSpeed;
    [SerializeField]
    float freaquencySpeed;
    [SerializeField]
    [Range(0.01F, 2F)]
    float timeoutperIteration = .1F;

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

    #region Unity Methods

    private void Start()
    {
        EventManager.OnFasterButtonPressed.AddListener(this.SetFastMode);
        EventManager.OnSlowDownButtonPressed.AddListener(this.SetSlowMode);
        sindeform = normalModeStaff.GetComponent<SineDeformer>();
    }


    #endregion
    #region Private Methods
    private void SetSlowMode()
    {
        StartCoroutine(SetAnimAndMode(this.fasterModeStaff));
    }
    private void SetFastMode()
    {
        StartCoroutine(SetAnimAndMode(this.slowerModeStaff));
    }
    IEnumerator SetAnimAndMode(GameObject objectToShow)
    {
        while (sindeform.AnimationSpeed < this.animSpeed
            || sindeform.Frequency < this.freaquencySpeed
            )
        {
            yield return new WaitForSeconds(timeoutperIteration);
            if (sindeform.AnimationSpeed < this.animSpeed)
                sindeform.AnimationSpeed += timeoutperIteration;
            if (sindeform.Frequency < this.freaquencySpeed)
                sindeform.Frequency += timeoutperIteration;
        }
        yield return new WaitForSeconds(timeoutperIteration);

      GameObject g=  Instantiate(objectToShow);
        g.transform.position = this.normalModeStaff.transform.position;
        g.transform.localScale = this.normalModeStaff.transform.localScale;
        Destroy(this.normalModeStaff);
        sindeform = g.GetComponent<SineDeformer>();
        sindeform.AnimationSpeed = this.animSpeed;
        sindeform.Frequency = this.freaquencySpeed;

        while (sindeform.AnimationSpeed > 0F
            || sindeform.Frequency >0F
            )
        {
            yield return new WaitForSeconds(timeoutperIteration);
            if (sindeform.AnimationSpeed > 0)
                sindeform.AnimationSpeed -= timeoutperIteration;
            if (sindeform.Frequency > 0)
                sindeform.Frequency -= timeoutperIteration;
        }
    }
    #endregion


}
