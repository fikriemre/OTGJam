using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class CubePlayer : Player
{

    public bool canMove;

    public bool canJump;


    public float groundCheckDistance;
    public LayerMask groundLayer;
    
    
    
    
    private void Update()
    {
        GroundCheck();

        if (Input.GetButtonDown("Jump"))
        {
            if(GroundCheck())
                Jump();
        }
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            ChangePlayerControl();
        }
        
    }

    private void FixedUpdate()
    {
        MoveHorizontal();
    }



    private void MoveHorizontal()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");      
        rb.velocity = new Vector2(moveHorizontal * speedMult * Time.deltaTime, rb.velocity.y);
        SFXManager.Instance.WalkSound( Mathf.Abs(moveHorizontal) >= 0.01f && GroundCheck());
        
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpMult, ForceMode2D.Impulse);
        SFXManager.Instance.JumpSound();
    }

    public bool GroundCheck()
    {
        Vector2 rayOrigin = new Vector2(transform.position.x, collider.bounds.min.y);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, groundCheckDistance, groundLayer);
        
        Debug.DrawRay(rayOrigin, Vector2.down * groundCheckDistance, Color.green);

        return hit.collider != null;
    }
    
}
