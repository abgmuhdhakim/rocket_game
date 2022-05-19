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
            else
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
    }

    public void Pause()
    {
        controlMenuGui.SetActive(false);
        pauseMenuGui.SetActive(true);
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
