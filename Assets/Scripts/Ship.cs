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
    private ICheckLimits _limits;

    private void Awake()
    {
        _camera = Camera.main;
        _transform = transform;
    }

    public void Configure(IInput input, ICheckLimits limits)
    {
        _limits = limits;
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
        _limits.ClampPosition();
    }

    private Vector2 GetDirection()
    {
        return _input.GetDirection();
    }
}