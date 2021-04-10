using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePlayer : Player
{

    public bool canMove;

    public bool canJump;


    private void Update()
    {


        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }

    private void FixedUpdate()
    {
        MoveHorizontal();
    }



    private void MoveHorizontal()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Debug.Log(moveHorizontal);

        rb.AddTorque(-speedMult * moveHorizontal);
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpMult, ForceMode2D.Impulse);
    }

}