﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{

    //Fall Speed
    public float fallMultiplier = 2.5f;
    //Low Jump
    public float lowJumpMultiplier = 2.5f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.y < 0){
            rb.velocity = new Vector2(rb.velocity.x , rb.velocity.y - (Time.deltaTime * (fallMultiplier - 1) * rb.gravityScale));
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")){
            rb.velocity = new Vector2(rb.velocity.x , rb.velocity.y - (Time.deltaTime * (lowJumpMultiplier - 1) * rb.gravityScale));
        }
    }
}
