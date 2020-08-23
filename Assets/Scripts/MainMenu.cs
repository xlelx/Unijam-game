using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public LevelLoader levelLoader;
    public void PlayGame()
    {
        levelLoader.LoadNextLevel();
    }

    public void QuitGame()
    {

        // Quitting inside the editor 
        // UnityEditor.EditorApplication.isPlaying = false;
        // Qutting the application 
        Application.Quit();
    }
}
