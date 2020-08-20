using UnityEngine;
using System.Collections;

public class BoxInteraction : MonoBehaviour
{

	public KeyCode button;

	FixedJoint2D boxJoint;

	GameObject box;
	// Use this for initialization
	void Start()
	{
		boxJoint = GetComponent<FixedJoint2D>();
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collision");
            if (Input.GetKey(button))
            {
                if(boxJoint.enabled)
                {
                    boxJoint.enabled = false;
                    Debug.Log("Detached");
                } else
                {
                    boxJoint.enabled = true;
                    boxJoint.connectedBody = collision.GetComponent<Rigidbody2D>();
                    Debug.Log("Attached");
                }
                
            }
        }
    }
}



