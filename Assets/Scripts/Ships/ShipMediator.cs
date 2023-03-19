using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(WeaponController))]
[RequireComponent(typeof(MovementController))]
public class ShipMediator : MonoBehaviour, IShip
{
    [SerializeField] private MovementController movementController;
    [SerializeField] private WeaponController weaponController;

    [SerializeField] private ShipID shipID;
    public ShipID ID => shipID;

    private Camera _camera;

    private IInput _input;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void Configure(IInput input, ICheckLimits limits, Vector2 speed, ProjectileId projectileId, float fireRate)
    {
        _input = input;
        movementController.Configure(this, limits, speed);
        weaponController.Configure(this, projectileId, fireRate);
    }

    void Update()
    {
        Vector2 direction = GetDirection();
        movementController.Move(direction);
        
        TryShoot();
    }

    private void TryShoot()
    {
        if (_input.IsFireActionPressed())
        {
            weaponController.TryShoot();
        }
    }

    private Vector2 GetDirection()
    {
        return _input.GetDirection();
    }
}