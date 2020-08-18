using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelLoader
{
    public enum Scene {
        MainMenu,
        Level01,
        Level02,
        Level03,
        Level04,
    }
    public static void Load(Scene scene){
        
        SceneManager.LoadScene(scene.ToString());
    }
}
