using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GamePause = false;
    public KeyCode pauseButton;
    private void Update() {
        if(Input.GetKeyDown(pauseButton)) {
            if (GamePause) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    void Resume() {
        
    }

    void Pause() {

    }
}
