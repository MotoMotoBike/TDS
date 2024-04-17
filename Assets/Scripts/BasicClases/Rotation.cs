using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Rotation : MonoBehaviour
{
    private Camera _camera;
    private void Start()
    {
        _camera = Camera.main;
    }

    public Vector2 GetNormalizedDirection(Vector2 point)
    {
        var worldPosition = _camera.ScreenToWorldPoint(point);
        return (Vector2)(worldPosition - transform.position).normalized;
    }

    public void RotateAtDirection(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            direction.Normalize();

            if (direction != Vector2.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }
    }
}

