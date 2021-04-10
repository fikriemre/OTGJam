using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leafPlayer : Player
{

    public bool canMove;

    public bool canJump;
    [Range(0,1)]
    public float WindSpeed;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TurnBackToOriginal();
        }
    }

    private void FixedUpdate()
    {
        MoveVertical();
        MoveHorizontal();
        Wind();
    }

    private void Wind()
    {
       
    }

    private void MoveVertical()
    {
        float MoveVertical = Input.GetAxis("Vertical");
        if (MoveVertical<0)
        {
            MoveVertical = 0;
        }
        Debug.Log(speedMult);

        rb.velocity = new Vector2( rb.velocity.x,MoveVertical * speedMult * Time.deltaTime);
    }

    private void MoveHorizontal()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveHorizontal * speedMult * Time.deltaTime, rb.velocity.y);
    }

}
