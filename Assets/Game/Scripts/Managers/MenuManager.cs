using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static PublicHardCodeds;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : SingletonCreator<MenuManager>
{
    [Header("Level WinScores")]
    [SerializeField]
    TextMeshProUGUI totalScore;
    [Space(3)]

    [Header("InGame Score")]
    [SerializeField]
    TextMeshProUGUI scoreTxt;
    [SerializeField]
    Text txtLvlIndex;
    [Space(3)]

    [SerializeField]
    GameStats currentGameStat;
    [SerializeField]
    GameObject InGamePanel;
    [SerializeField]
    GameObject WinPanel;
    [SerializeField]
    GameObject LosePanel;
    [SerializeField]
    GameObject TaptoPlayPanel;
   

    private void Awake()
    {
        instance = this;
        DOTween.Init();
        DOTween.SetTweensCapacity(500, 500);
        currentGameStat = GameStats.TapToPlay;
        Application.targetFrameRate = 60;
        EventManager.OnGameSuccess.AddListener(this.SetWinPanel);
        EventManager.OnGameFail.AddListener(this.SetLosePanel);
        txtLvlIndex.text = $"Level { SceneManager.GetActiveScene().buildIndex}";
        SetTapToPlayPanel();
    }
    void DisableAllPanels()
    {
        InGamePanel.SetActive(false);
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
        TaptoPlayPanel.SetActive(false);
    }

    public void SetTapToPlayPanel()
    {
        currentGameStat = GameStats.TapToPlay;
        DisableAllPanels();
        TaptoPlayPanel.SetActive(true);
        scoreTxt.text = "";
        totalScore.text = "0";
    }
    public void SetInGamePanel()
    {
        
        currentGameStat = GameStats.InGame;
        DisableAllPanels();
        InGamePanel.SetActive(true);
        EventManager.OnGameStarted.Invoke();


    }

    public void SetWinPanel()
    {
        currentGameStat = GameStats.Win;
        DisableAllPanels();
        WinPanel.SetActive(true);
    }

    public void SetLosePanel()
    {
        currentGameStat = GameStats.Lose;
        DisableAllPanels();
        StartCoroutine(waitTimeOut());

    }


    public void SetTotalScores(int calculatedTotalScore)
    {
        this.totalScore.text = calculatedTotalScore.ToString();
    }

    public void SetInGameScore(int score)
    {
        this.scoreTxt.text = score.ToString();
    }


    IEnumerator waitTimeOut()
    {
        yield return new WaitForSeconds(2);
        LosePanel.SetActive(true);

    }
}
