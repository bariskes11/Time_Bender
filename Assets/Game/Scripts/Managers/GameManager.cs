using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : SingletonCreator<GameManager>
{
    #region Unity Fields
    [SerializeField]
    [Header("Time Out after finish part invoked")]
    float timeoutCounterforFinish = 5F;
    [SerializeField]
    [Header("This value should be between 0 and max human count")]
    [Range(0,100)]
    float minPercentForsuccess;

    [SerializeField]
    TextMeshProUGUI deathPersonCount;
    [SerializeField]
    ParticleSystem failedParticle;
    [SerializeField]
    ParticleSystem successParticle;



    #endregion
    #region Fields
    PlayerAnimController playerAnimsys;
    int humanCountForSave;
    int currentHumanleftToSave;
    float currentPercent = 0;
    #endregion
    #region Unity Methods
    private void Start()
    {
        currentPercent = 100;
        playerAnimsys = GameObject.FindObjectOfType<PlayerAnimController>();
        if (!playerAnimsys)
        {
            Debug.Log("<color=red> There is no PlayerAnimController in Scene</color>");
        }
        humanCountForSave = GameObject.FindObjectsOfType<PersonhitSystem>().Length;
        currentHumanleftToSave = humanCountForSave;
        if (humanCountForSave == 0)
        {
            Debug.Log($"<color=red> there is no person to save!!! add some people to game field</color>");
        }
        EventManager.OnStartCountDown.AddListener(this.StartCoundownSystem);
        EventManager.OnPersonDied.AddListener(this.SetHumanDied);
    }
    #endregion
    #region Private Methods
    void CheckFailSuccess()
    {
        if (minPercentForsuccess > this.currentPercent)
        {
            // failed
            playerAnimsys.ChangeToFailState();
            failedParticle.Play();
          StartCoroutine(  WaitTimeOutandInvokeEvent(false));


        }
        else
        {
            //success
            playerAnimsys.ChangeToVictoryState();
            successParticle.Play();
            StartCoroutine(WaitTimeOutandInvokeEvent(true));
            //mayube other humans can be happy about stuation

        }
    }

    IEnumerator WaitTimeOutandInvokeEvent(bool isWin)
    {
        yield return new WaitForSeconds(1F);
        if (isWin)
        {

            
            SetHappyAnimationForHumans();
            yield return new WaitForSeconds(1.5F);
            EventManager.OnGameSuccess.Invoke();

        }
        else
        {
            EventManager.OnGameFail.Invoke();
            SetSorryAnimForHumans();
        }



    }

    void SetSorryAnimForHumans()
    {
        var aliveHumans = GameObject.FindObjectsOfType<PersonhitSystem>();
        foreach (var item in aliveHumans)
        {
            item.GetComponent<Animator>().SetBool("Sorry", true);
        }
    }
    void SetHappyAnimationForHumans()
    {
       var aliveHumans= GameObject.FindObjectsOfType<PersonhitSystem>();
        foreach (var item in aliveHumans)
        {
            item.GetComponent<Animator>().SetBool("Happy", true);
        }
    }
    void SetHumanDied()
    {
        currentHumanleftToSave--;
        this.currentPercent = ((float)currentHumanleftToSave / (float)humanCountForSave)*100;
        deathPersonCount.text = $"Saved %{currentPercent.ToString("#.##")} of People";
    }
    void StartCoundownSystem()
    {
        StartCoroutine(CountDownCoroutine());
    }
    IEnumerator CountDownCoroutine()
    {
        yield return new WaitForSeconds(timeoutCounterforFinish);


        CheckFailSuccess();

    }

     
    #endregion
}
