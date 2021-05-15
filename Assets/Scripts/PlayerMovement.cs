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
                transform.Rotate(new Vector3(0, 180, 0));
                facingright = true;
                facingleft = false;
            }
            if (Input.GetKeyDown(KeyCode.A) && facingleft == false)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                facingleft = true;
                facingright = false;
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