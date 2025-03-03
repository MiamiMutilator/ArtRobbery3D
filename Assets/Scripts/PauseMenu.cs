 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject optionUI;
    public bool isPaused;

    void Start()
    {
        pauseMenuUI.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (isPaused && pauseMenuUI != null || isPaused && optionUI != null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);  
        Time.timeScale = 0f;        
        isPaused = true;            
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        optionUI.SetActive(false);
        Time.timeScale = 1f;        
        isPaused = false;
    }
}