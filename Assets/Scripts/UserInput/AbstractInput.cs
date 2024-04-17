using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Rotation))]
public abstract class AbstractInput : MonoBehaviour
{
    [SerializeField] internal RuntimePlatform[] _availablePlatforms;
    internal Movement movement;
    internal Rotation rotation;
    internal WeaponUser weaponUser;
    private void Start()
    {
        if (!_availablePlatforms.Contains(Application.platform))
        {
            RemoveInputSystem();
        }

        TryGetComponent(out movement);
        TryGetComponent(out rotation);
        TryGetComponent(out weaponUser);
    }

    private void Update()
    {
        movement.MoveAtDirection(HandleMovementInput());
        rotation.RotateAtDirection(HandleRotationInput());
        if (HandleFireInput())
        {
            weaponUser.TryToFire();
        }
    }

    protected abstract Vector2 HandleMovementInput();
    protected abstract Vector2 HandleRotationInput();
    protected abstract bool HandleFireInput();
    protected abstract void RemoveInputSystem();
}

