using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : NetworkBehaviour
{
    [SerializeField] private Transform orientation;
    
    private Camera _camera;
    private Vector2 _mousePosition;
    private Plane _plane;

    private void Awake()
    {
        _camera = Camera.main;
        _plane = new Plane(Vector3.down, transform.position.y);
    }

    private void LateUpdate()
    {
        Ray ray = _camera.ScreenPointToRay(_mousePosition);
        _plane.Raycast(ray, out float distance);
        Vector3 target = ray.GetPoint(distance);
        orientation.LookAt(target);
    }

    public void LookAction(InputAction.CallbackContext context)
    {
        _mousePosition = context.ReadValue<Vector2>();
    }
}