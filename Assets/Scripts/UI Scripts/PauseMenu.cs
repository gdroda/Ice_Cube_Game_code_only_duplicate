using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject verificationUI;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        if (verificationUI.activeSelf.Equals(false))
        {
            verificationUI.SetActive(true);
            pauseMenuUI.SetActive(false);
        }
        else
        {
            verificationUI.SetActive(false);
            pauseMenuUI.SetActive(true);
        }
    }
}
