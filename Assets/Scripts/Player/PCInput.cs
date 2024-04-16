using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Movement))]
public class PCInput : AbstractInput
{
    protected override void RemoveInputSystem()
    {
        Destroy(this);
    }

    protected override Vector2 HandleRotationInput()
    {
        return Rotation.GetNormalizedDirection(Input.mousePosition);
    }
    protected override Vector2 HandleMovementInput()
    {
        return new Vector2(Input.GetAxis("HorizontalMovement"),Input.GetAxis("VerticalMovement"));
    }
}

