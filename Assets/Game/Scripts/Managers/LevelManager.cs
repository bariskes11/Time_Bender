using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    
    public void LoadNextLevel()
    {
       int curIndex=  SceneManager.GetActiveScene().buildIndex+1;
        curIndex= curIndex++;
        if (SceneManager.sceneCountInBuildSettings <= curIndex)
        {
            curIndex = 0;
        }
        SceneManager.LoadScene(curIndex);
        MenuManager.instance.SetTapToPlayPanel();
    }
    public void Start()
    {
        string name = SceneManager.GetActiveScene().name;
        if (name == "Boot")
        {
            this.LoadNextLevel();
        }
    }
    public void ReloadCurrentLevel()
    {
        this.GetComponentInParent<MenuManager>().SetInGamePanel();
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelIndex);
        MenuManager.instance.SetTapToPlayPanel();
    }
}
