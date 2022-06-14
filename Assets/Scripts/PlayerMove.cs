using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : NetworkBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;

        _rigidbody.MovePosition(_rigidbody.position + _moveDirection * (speed * Time.fixedDeltaTime));
}

    public void MoveAction(InputAction.CallbackContext context)
    {
        if (!IsOwner) return;
        
        Vector2 moveDirection = context.ReadValue<Vector2>();
        _moveDirection = new Vector3(moveDirection.x, 0, moveDirection.y);
    }
}