using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public KeyCode open;
    
    BoxCollider2D doorCollider;
    // Start is called before the first frame update
    void Start()
    {
        doorCollider = this.GetComponent<BoxCollider2D>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(open))
            {
                doorCollider.enabled = !doorCollider.enabled; 
                Debug.Log("Reached");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
