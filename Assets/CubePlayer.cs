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
       

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
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
<<<<<<< Updated upstream
        
        Debug.Log(speedMult);
        
        rb.velocity = new Vector2(moveHorizontal * speedMult * Time.deltaTime, rb.velocity.y);
=======

        rb.velocity = new Vector2(moveHorizontal * speedMult * Time.fixedDeltaTime, rb.velocity.y);
>>>>>>> Stashed changes
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpMult, ForceMode2D.Impulse);
    }
    
}
