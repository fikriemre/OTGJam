using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move
{
    public abstract void MoveHorizontal(Vector2 moveVector, Rigidbody2D rb);

    public abstract void Jump(float jumpMult, Rigidbody2D rb);

}

public class PlayerMove : Move
{
    public override void MoveHorizontal(Vector2 moveVector, Rigidbody2D rb)
    {
        
    }

    public override void Jump(float jumpMult, Rigidbody2D rb)
    {
        
    }
}

public class StoneMove : Move
{
    public override void MoveHorizontal(Vector2 moveVector, Rigidbody2D rb)
    {
        
    }

    public override void Jump(float jumpMult, Rigidbody2D rb)
    {
        
    }
}

public class BushMove : Move
{
    public override void MoveHorizontal(Vector2 moveVector, Rigidbody2D rb)
    {
        
    }

    public override void Jump(float jumpMult, Rigidbody2D rb)
    {
        
    }
}
