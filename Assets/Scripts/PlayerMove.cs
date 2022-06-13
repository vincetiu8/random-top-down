using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _moveDirection);
    }

    public void MoveAction(InputAction.CallbackContext context)
    {
        Vector2 moveDirection = context.ReadValue<Vector2>() * speed;

        _moveDirection = new Vector3(moveDirection.x, 0, moveDirection.y);
    }
}
