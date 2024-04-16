using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForvardMovement : Movement
{
    // Update is called once per frame
    void FixedUpdate()
    {
        MoveAtDirection(transform.up);
    }
}
