using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScene : MonoBehaviour
{
    public Rigidbody2D hansel;
    public Rigidbody2D gretel;
    public Animator hanselAnim;
    public Animator gretelAnim;
    bool playingAnimation = false;
    public void playScene() {
        playingAnimation = true; 
    }

    private void Update() {
        if(playingAnimation) {
            
            // Adding velocity 
            hansel.velocity = new Vector2(3, 0); 
            gretel.velocity = new Vector2(-3, 0); 

            // Set the animation 
            hanselAnim.SetFloat("speed", Mathf.Abs(3 * 3));
            gretelAnim.SetFloat("speed", Mathf.Abs(3 * 3));
        }
    }
}
