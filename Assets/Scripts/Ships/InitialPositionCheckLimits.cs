using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPositionCheckLimits : ICheckLimits
{
    private Transform _transform;
    private Vector2 _initialPosition;
    private float _maxDistance;
    
    public InitialPositionCheckLimits(Transform transform, float maxDistance)
    {
        _transform = transform;
        _initialPosition = transform.position;
        _maxDistance = maxDistance;
    }
    
    public void ClampPosition()
    {
        Vector2 currentPos = _transform.position;
        Vector2 finalPos = currentPos;
        float distance = Mathf.Abs(currentPos.x - _initialPosition.x);

        if ((distance <= _maxDistance)) return;
        
        if (currentPos.x > _initialPosition.x)
        {
            finalPos.x = _initialPosition.x + _maxDistance;
        }
        else
        {
            finalPos.x = _initialPosition.x - _maxDistance;
        }

        _transform.position = finalPos;
    }
}
