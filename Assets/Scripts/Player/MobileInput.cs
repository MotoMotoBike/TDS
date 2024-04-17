using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Rotation))]
public class MobileInput : AbstractInput
{
    [SerializeField] private Joystick MovementJoystick;
    [SerializeField] private Joystick RotationJoystick;
    
    protected override void RemoveInputSystem()
    {
        Destroy(MovementJoystick.gameObject);
        Destroy(this);
    }
    protected override Vector2 HandleRotationInput()
    {
        return RotationJoystick.Direction;
    }

    protected override bool HandleFireInput()
    {
        return RotationJoystick.Direction != Vector2.zero;
    }

    protected override Vector2 HandleMovementInput()
    {
        return MovementJoystick.Direction;
    }
}

