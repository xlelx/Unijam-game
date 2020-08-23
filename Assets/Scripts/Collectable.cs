using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool collected = false;
    public GoalDetector gd;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            collected = true;
            gameObject.SetActive(false);
            gd.OpenPortal();
            SoundManagerScript.PlaySound("collect");
        }
    }
}
