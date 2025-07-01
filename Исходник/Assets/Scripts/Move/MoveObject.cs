using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveObject : MonoBehaviour
{
    protected void MoveObjectMeth(bool GoRight, bool GoLeft, bool GoUp, bool GoDown, Rigidbody2D _rigidbody2D, float speed)
    {
        Vector2 movement = Vector2.zero;

        if (GoRight)
        {
            movement.x += 1;
        }
        if (GoLeft)
        {
            movement.x -= 1; 
        }
        if (GoUp)
        {
            movement.y += 1;
        }
        if (GoDown)
        {
            movement.y -= 1; 
        }
        _rigidbody2D.velocity = movement.normalized * speed * Time.fixedDeltaTime;
    }
}
