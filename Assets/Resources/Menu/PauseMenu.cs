using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;

    public GameObject pauseMenu;
    public GameObject optionsMenu;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        Map();
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public GameObject map;
    public Camera mapCamera;

    public void Map()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(!map.active)
            {
                map.SetActive(true);
            }
            else
            {
                map.SetActive(false);
            }
        }
        if(map.active)
        {
            mapCamera.orthographicSize += Input.GetAxis("Mouse ScrollWheel") * 5;
        }
    }
}
