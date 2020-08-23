using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    BoxCollider2D doorCollider;
    // Start is called before the first frame update
    void Start()
    {
        doorCollider = this.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Door opening animation here 
        if(collision.tag == "Player") {
            
        }
    }

    
}
