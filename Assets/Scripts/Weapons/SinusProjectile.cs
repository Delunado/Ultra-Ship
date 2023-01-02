using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusProjectile : BaseProjectile
{
    [SerializeField] private float _speed;
    [SerializeField] private float _amplitude;
    [SerializeField] private float _frequency;

    private Vector3 _initialPosition;
    private float _currentTime;

    protected override void DoStart()
    {
        _currentTime = 0.0f;
        _initialPosition = transform.position;
    }

    protected override void DoMove()
    {
        _currentTime += Time.time;

        _initialPosition += transform.up * (_speed * Time.deltaTime);
        Vector3 horizontalPos = transform.right * (_amplitude * Mathf.Sin(_currentTime) * _frequency);
        rb.MovePosition(_initialPosition + horizontalPos);
    }

    protected override void DoDestroy()
    {
    }
}