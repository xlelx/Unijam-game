using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private Animator transition;

    
    public float fadeTime = 2f;

    private void Awake() {
        transition = GetComponent<Animator>();    
    }

    public void RestartLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));

    }
    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMenu(){
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("FadeOut");

        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(levelIndex);
    }
}
