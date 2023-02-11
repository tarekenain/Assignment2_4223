using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    
    private bool isPaused = false;
    public GameObject SettingsPanel;

    
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        SettingsPanel.gameObject.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        SettingsPanel.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Exit");
    }
}
