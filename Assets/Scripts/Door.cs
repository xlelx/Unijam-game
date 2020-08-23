using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    BoxCollider2D doorCollider;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        doorCollider = this.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Door opening animation here 
            animator.SetBool("openDoor", true);
            
            

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") {
            animator.SetBool("openDoor", false);
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }


}
