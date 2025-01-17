﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingScene : MonoBehaviour
{

    public Rigidbody2D hansel;
    public Rigidbody2D gretel;
    // Animators 
    public Animator hanselAnim;
    public Animator gretelAnim;

    // Texts 

    bool playingAnimation = false;
    public void playScene()
    {
        playingAnimation = true;
    }

    private void Update()
    {
        if (playingAnimation)
        {

            // Adding velocity 
            hansel.velocity = new Vector2(3, 0);
            gretel.velocity = new Vector2(3, 0);
            SoundManagerScript.PlaySound("walk");
            // Set the animation 
            hanselAnim.SetFloat("speed", Mathf.Abs(3 * 3));
            gretelAnim.SetFloat("speed", Mathf.Abs(3 * 3));

        }
    }
}
