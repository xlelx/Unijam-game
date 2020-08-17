using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Update is called once per frame

    [Range(0, 10)]
    public float moveSpeed = 10f;
    [Range(0, 10)]
    public float jumpSpeed = 10f;

    private Rigidbody2D rb;
    private float movement;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Horizontal movement
        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);

        //Jumping
        if (Input.GetButtonDown("Jump")){
            rb.velocity = new Vector3(rb.velocity.x , rb.velocity.y + jumpSpeed);
        }
    }
}
