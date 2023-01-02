using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveProjectile : BaseProjectile
{
    [SerializeField] private float _speed;
    [SerializeField] private AnimationCurve _horizontalPosition;

    private Vector3 _initialPosition;
    private float _currentTime;

    protected override void DoStart()
    {
        _currentTime = 0.0f;
    }

    protected override void DoMove()
    {
        _initialPosition += transform.up * (_speed * Time.deltaTime);

        Vector3 horizontalPos = transform.right * _horizontalPosition.Evaluate(_currentTime);
        rb.MovePosition(_initialPosition + horizontalPos);

        _currentTime += Time.time;
    }

    protected override void DoDestroy()
    {
    }
}