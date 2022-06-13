using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    
    private Plane _flat;
    private Camera _cam;
    private Vector3 _mousePos;

    private void Awake()
    {
        _cam = GetComponentInChildren<Camera>();
        _flat = new Plane(Vector3.down, transform.position.y);
    }

    private void LateUpdate()
    {
        Ray ray = _cam.ScreenPointToRay(_mousePos);
        _flat.Raycast(ray, out float enter);
        Vector3 hitPoint = ray.GetPoint(enter);
        orientation.LookAt(hitPoint);
    }

    public void LookAction(InputAction.CallbackContext context)
    {
        _mousePos = context.ReadValue<Vector2>();

    }
}