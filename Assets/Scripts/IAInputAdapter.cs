using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInputAdapter : IInput
{
    private readonly Ship _ship;
    private int _currentDirectionX;

    public IAInputAdapter(Ship ship)
    {
        _ship = ship;
        _currentDirectionX = 1;
    }

    public Vector2 GetDirection()
    {
        var viewportPoint = Camera.main.WorldToViewportPoint(_ship.transform.position);
        if (viewportPoint.x < 0.05f || viewportPoint.x > 0.95f)
        {
            _currentDirectionX *= -1;
        }
        
        return new Vector2(_currentDirectionX, 0.0f);
    }
}