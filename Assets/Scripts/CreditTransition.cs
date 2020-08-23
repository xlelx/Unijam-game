using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditTransition : MonoBehaviour
{
    public LevelLoader levelLoader;
    public float time = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0 ){
            levelLoader.LoadMenu();

        }
    }
}
