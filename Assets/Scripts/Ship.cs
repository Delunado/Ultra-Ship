using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform _transform;
    private Camera _camera;

    private IInput _input;

    private void Awake()
    {
        _camera = Camera.main;
        _transform = transform;
    }

    public void Configure(IInput input)
    {
        _input = input;
    }
    
    void Update()
    {
        Vector2 direction = GetDirection();
        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        _transform.Translate(direction * (speed * Time.deltaTime));
        ClampWorldPosition();
    }

    //Limits the World position using the Viewport position
    private void ClampWorldPosition()
    {
        Vector3 viewportPoint = _camera.WorldToViewportPoint(_transform.position);
        viewportPoint.x = Mathf.Clamp(viewportPoint.x, 0.03f, 0.97f);
        viewportPoint.y = Mathf.Clamp(viewportPoint.y, 0.03f, 0.97f);
        _transform.position = _camera.ViewportToWorldPoint(viewportPoint);
    }

    private Vector2 GetDirection()
    {
        return _input.GetDirection();
    }
}