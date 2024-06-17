using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, jumpForce;
    public Transform floorDetector;
    public LayerMask layer;
    private float axisX;
    private Rigidbody2D rb;
    private Animator anim;
    private bool canJump;
    public int dJump = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        axisX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(axisX * speed, rb.velocity.y);

        if (axisX > 0) transform.localScale = new Vector2(1, 1);
        else if(axisX < 0) transform.localScale = new Vector2(-1, 1);

        if (canJump == true) 
        {
            if (axisX != 0) anim.SetInteger("state", 1);
            else if (axisX == 0) anim.SetInteger("state", 0);
        }
        else 
        {
            if (rb.velocity.y > 0)
            {
                if(dJump == 1) anim.SetInteger("state", 2);
                else if(dJump == 2) anim.SetInteger("state", 3);
            }
            else if (rb.velocity.y < 0) anim.SetInteger("state", 4);
        }

        canJump = Physics2D.Linecast(transform.position, floorDetector.position, layer);

        if (axisX != 0) anim.SetInteger("state", 1);
        else if (axisX == 0) anim.SetInteger("state", 0);

        if (Input.GetKeyDown(KeyCode.Space) && dJump < 2)
        {
            StartCoroutine(AddJump());
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (canJump == true) { dJump = 0; }
    }

    IEnumerator AddJump()
    {
        yield return new WaitForSeconds(0.1f);
        dJump++;
    }
}
