using UnityEngine;
using System.Collections.Generic;

public class GridView : MonoBehaviour
{
    public KeyCode toggle;

    void Update()
    {
        if(Input.GetKeyDown(toggle))
        {
            this.GetComponent<SpriteRenderer>().enabled = 
                !this.GetComponent<SpriteRenderer>().enabled;
        }
    }

    
}