using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayer : Player
{

    public bool canMove;

    public bool canJump;
    
    
    private void Update()
    {
        MoveHorizontal();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        
    }

    private void FixedUpdate()
    {

    }

    private void MoveHorizontal()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        Debug.Log(moveHorizontal);
        
        rb.velocity = new Vector2(moveHorizontal * speedMult * Time.deltaTime, rb.velocity.y);
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpMult, ForceMode2D.Impulse);
    }
    
}
