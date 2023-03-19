using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Vector2 speed;
    
    private IShip _ship;
    private ICheckLimits _limits;

    public void Configure(IShip ship, ICheckLimits limits)
    {
        _ship = ship;
        _limits = limits;
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction * (speed * Time.deltaTime));
        ClampWorldPosition();
    }
    
    private void ClampWorldPosition()
    {
        _limits.ClampPosition();
    }
}
