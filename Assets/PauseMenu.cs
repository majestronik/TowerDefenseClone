using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausedUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }
    
    public void Toggle()
    {
        pausedUI.SetActive(!pausedUI.activeSelf);
        if (pausedUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Retry()
    {
        Toggle();
        GameOver.Retry();
    }
    public void Menu()
    {
        Debug.Log("Go to menu");
    }
}
