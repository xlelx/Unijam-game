using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;

    public Animator animator;
    
    GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Physics2D.queriesStartInColliders = false;
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position,
            Vector2.right * transform.localScale.x, distance, boxMask);

        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position,
            Vector2.left * transform.localScale.x, distance, boxMask);

        if(hitRight.collider != null && Input.GetKeyDown(KeyCode.E))
        {
            // Get the game object it hit with 
            box = hitRight.collider.gameObject;
            // Ensure the player cannot jump & play animations 
            GetComponent<CharacterController>().canJump = false;
            animator.SetBool("isPushing", true);
            // Attach box with the player 
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxMove>().beingPushed = true;
            //box.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();

        } else if (hitLeft.collider != null && Input.GetKeyDown(KeyCode.E)) 
        {
            // Do the same steps as previous except for the left side 
            box = hitLeft.collider.gameObject;

            GetComponent<CharacterController>().canJump = false;
            animator.SetBool("isPushing", true);
            
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxMove>().beingPushed = true;
            //box.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            // Enable player jump and disable animation 
            GetComponent<CharacterController>().canJump = true;
            animator.SetBool("isPushing", false);
            // Detach the box from the player 
            box.GetComponent<BoxMove>().beingPushed = false;
            box.GetComponent<FixedJoint2D>().enabled = false;
            //box.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position +
            Vector2.right * distance); 
    }
}
