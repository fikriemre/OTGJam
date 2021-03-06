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

        if (Input.GetKeyDown(KeyCode.F))
        {
            TurnBackToOriginal();
        }

    }

    private void FixedUpdate()
    {
        MoveHorizontal();
    }

    private void MoveHorizontal()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.AddTorque(-speedMult * moveHorizontal);
        SFXManager.Instance.WalkSound(Mathf.Abs(moveHorizontal) >= 0.01f);
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpMult, ForceMode2D.Impulse);
        SFXManager.Instance.JumpSound();
    }

}