using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpSpeed = 20f;


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            CharacterController playerScript = other.gameObject.GetComponent<CharacterController>();
            playerScript.Jump(jumpSpeed);
        }
    }
}
