using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Rotation))]
public abstract class AbstractInput : MonoBehaviour
{
    [SerializeField] internal RuntimePlatform[] _availablePlatforms;
    internal Movement Movement;
    internal Rotation Rotation;
    internal WeaponUser weaponUser;
    private void Start()
    {
        if (!_availablePlatforms.Contains(Application.platform))
        {
            RemoveInputSystem();
        }
        
        Movement = GetComponent<Movement>();
        Rotation = GetComponent<Rotation>();
    }

    private void Update()
    {
        Movement.MoveAtDirection(HandleMovementInput());
        Rotation.RotateAtDirection(HandleRotationInput());
    }

    protected abstract Vector2 HandleMovementInput();
    protected abstract Vector2 HandleRotationInput();
    protected abstract void RemoveInputSystem();
}

