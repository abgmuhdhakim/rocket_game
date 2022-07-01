using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public static bool onControl = false;

    public GameObject pauseMenuGui;

    public GameObject controlMenuGui;

    public GameObject pressGui;
    void Start()
    {
        Resume();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused == true && onControl == false)
            {
                Resume();
            }
            else if(GameIsPaused == false && onControl == false)
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuGui.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        pressGui.SetActive(true);
    }

    public void Pause()
    {
        controlMenuGui.SetActive(false);
        pauseMenuGui.SetActive(true);
        pressGui.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        onControl = false;
    }

    public void Control()
    {
        pauseMenuGui.SetActive(false);
        controlMenuGui.SetActive(true);
        onControl = true;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
