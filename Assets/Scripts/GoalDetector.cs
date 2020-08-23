using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalDetector : MonoBehaviour
{
    private int numInGoal = 0; 
    public bool portalOpen = true;

    private Animator animator;

    public LevelLoader levelLoader;

    private void Start(){
        animator = GetComponent<Animator>();
        animator.SetBool("isOpen", portalOpen);
    }
    private void Update() {
        
        if (portalOpen && numInGoal == 2){
            //TODO animations or somestuff before loading the next level
            SoundManagerScript.PlaySound("portal");
            levelLoader.LoadNextLevel();
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

    public void OpenPortal(){
        portalOpen = true;
        animator.SetBool("isOpen", true);
        
    }
}
