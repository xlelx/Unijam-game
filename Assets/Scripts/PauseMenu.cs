using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gamePause = false;
    public KeyCode pauseButton;
    public GameObject pauseMenuUI;

    public LevelLoader levelLoader;

    private void Update() {
        if(Input.GetKeyDown(pauseButton)) {
            if (gamePause) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePause = false;
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePause = true;
    }

    public void RestartLevel() {
        Time.timeScale = 1f;
        gamePause = false;
        levelLoader.RestartLevel();
    }
    public void LoadMenu() {
        Time.timeScale = 1f;
        gamePause = false;
        levelLoader.LoadMenu();
    }

    public void Quit() {
        // Quitting inside the editor 
        // UnityEditor.EditorApplication.isPlaying = false;
        // Qutting the application 
        Application.Quit();
    }
}
