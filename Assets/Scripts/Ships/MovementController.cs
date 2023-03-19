using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Vector2 _speed;
    
    private IShip _ship;
    private ICheckLimits _limits;

    public void Configure(IShip ship, ICheckLimits limits, Vector2 speed)
    {
        _ship = ship;
        _limits = limits;
        _speed = speed;
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction * (_speed * Time.deltaTime));
        ClampWorldPosition();
    }
    
    private void ClampWorldPosition()
    {
        _limits.ClampPosition();
    }
}
