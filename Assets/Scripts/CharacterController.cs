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

    public Animator animator;

    [SerializeField]
    public bool invertDirection = false;

    [SerializeField]
    public LayerMask platformLayerMask;

    private Rigidbody2D rb;
    private float movement;
    private BoxCollider2D boxCollider;

    private bool prevGrounded = true;

    public bool canJump = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //Horizontal movement
        movement = Input.GetAxis("Horizontal") * (invertDirection ? -1 : 1);

        animator.SetFloat("verticalSpeed", rb.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(movement * moveSpeed));

        Transform pTransform = transform.parent.gameObject.transform;
        if (movement < 0f)
        {
            SoundManagerScript.PlaySound("walk");
            pTransform.localScale = new Vector2(Mathf.Abs(pTransform.localScale.x) * -1, pTransform.localScale.y);
        }
        else if (movement > 0f)
        {
            SoundManagerScript.PlaySound("walk");
            pTransform.localScale = new Vector2(Mathf.Abs(pTransform.localScale.x), pTransform.localScale.y);
        }
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);


        //Check for jump
        bool grounded = isGroundedAnim();
        if (grounded && !prevGrounded) animator.SetBool("hasJumped", false);
        else if (grounded && rb.velocity.y == 0) animator.SetBool("hasJumped", false);
        prevGrounded = grounded;

        if (canJump && isGrounded() && Input.GetButtonDown("Jump"))
        {
            SoundManagerScript.PlaySound("jump");

            Jump(this.jumpSpeed);
        }

        pTransform.position = transform.position;
        transform.localPosition = Vector3.zero;
    }

    public void Jump(float jumpSpeed)
    {
        animator.SetBool("hasJumped", true);

        rb.velocity = new Vector3(rb.velocity.x, jumpSpeed);

    }
    bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, jumpBuffer, platformLayerMask);

        return raycastHit.collider != null;
    }

    bool isGroundedAnim()
    {
        float extraHeight = 1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + extraHeight, platformLayerMask);

        return raycastHit.collider != null;
    }
}
