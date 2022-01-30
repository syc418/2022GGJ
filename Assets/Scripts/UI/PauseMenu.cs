using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
