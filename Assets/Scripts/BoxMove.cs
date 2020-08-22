using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    public bool beingPushed;
    float xPos;

    // Start is called before the first frame update
    void Start()
    {
        xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(beingPushed) {
            xPos = transform.position.x;
        } else {
            transform.position = new Vector3(xPos, transform.position.y);
        }
    }
}
