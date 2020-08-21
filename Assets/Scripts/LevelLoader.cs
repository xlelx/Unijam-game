using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelLoader
{
    
    public enum Scene {
        Menu,
        Level01,
        Level02,
        Level03,
        Level04,
        CastleScene,
    }
    public static Scene currentScene = Scene.CastleScene;
    public static void Load(Scene scene){
        currentScene = scene;
        SceneManager.LoadScene(scene.ToString());
    }

    public static void RestartLevel(){
        SceneManager.LoadScene(currentScene.ToString());
    }
}
