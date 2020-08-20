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

    //Buffer Distance from ground to enable jump
    public float jumpBuffer = 1f;

    [SerializeField]
    public bool invertDirection = false;

    [SerializeField]
    public LayerMask platformLayerMask;

    private Rigidbody2D rb;
    private float movement;
    private BoxCollider2D boxCollider;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //Horizontal movement
        movement = Input.GetAxis("Horizontal") * (invertDirection ?  -1 : 1);
        if (movement < 0f){
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y);
        }
        else if (movement > 0f){
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);


        //Jumping
        if (isGrounded() && Input.GetButtonDown("Jump")){
            rb.velocity = new Vector3(rb.velocity.x , rb.velocity.y + jumpSpeed);
        }
    }

    bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, jumpBuffer, platformLayerMask);

        return raycastHit.collider != null;
    }
}
