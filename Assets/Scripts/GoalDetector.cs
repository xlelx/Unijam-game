using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    private int numInGoal = 0;  
    private void Update() {
        if (numInGoal == 2){
            //TODO animations or somestuff before loading the next level
            LevelLoader.Load(LevelLoader.Scene.Level01);
            Debug.Log("Level Complete!");
        }    
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            numInGoal++;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player"){
            numInGoal--;
        }
    }
}
