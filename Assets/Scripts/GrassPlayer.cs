using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPlayer : Player
{

    void Start()
    {
        
    }


    void Update()
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
        float MoveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveHorizontal * speedMult * Time.deltaTime, rb.velocity.y);
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpMult, ForceMode2D.Impulse);
        SFXManager.Instance.JumpSound();
    }
}
