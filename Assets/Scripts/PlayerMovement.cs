using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

    Rigidbody2D body;
    public Animator animator;

    public float move;
    float horizontal;
    float vertical;

    bool facingright;
    bool facingleft;

    private Camera Camera;

    public float runSpeed = 3f;

    void Start()
    {
        facingright = false;
        facingleft = true;


        body = GetComponent<Rigidbody2D>();

        
    }


    void HandleMovement()
    {
        if (isLocalPlayer)
        {
            move = (Input.GetAxis("Horizontal") + Input.GetAxis("Vertical")) * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(move));

            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(KeyCode.D) && facingright == false)
            {
                animator.SetBool("right", true);
                animator.SetBool("left", false);
                facingright = true;
                facingleft = false;
            }
            if (Input.GetKeyDown(KeyCode.A) && facingleft == false)
            {
                animator.SetBool("left", true);
                animator.SetBool("right", false); 
                facingright = false;
                facingleft = true;

            }
        }

    }


    public void Update()
    {
        HandleMovement();

    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}