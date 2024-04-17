using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D _rigidbody2D;
    public UnityEvent OnWalking;
    public UnityEvent OnStoped;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void MoveAtDirection(Vector2 direction)
    {
        Vector2 velocity = direction * speed;

        if (velocity != Vector2.zero)
        {
            OnWalking?.Invoke();
        }
        else
        {
            OnStoped?.Invoke();
        }
        _rigidbody2D.velocity = velocity;
    }
}