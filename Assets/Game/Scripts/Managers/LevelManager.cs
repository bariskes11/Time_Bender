using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int LevelIndex = 1;
    public void LoadNextLevel()
    {
        this.LevelIndex += 1;
        SceneManager.LoadScene(this.LevelIndex);
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
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        LevelIndex = levelIndex;
        SceneManager.LoadScene(LevelIndex);
        MenuManager.instance.SetTapToPlayPanel();
    }
}
