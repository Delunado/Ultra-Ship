using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float _fireRateInSeconds;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPos;

    private Transform _transform;
    private Camera _camera;

    private IInput _input;
    private ICheckLimits _limits;

    private float _remainingSecondsToCanShoot;

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
        
        TryShoot();
    }

    private void Move(Vector2 direction)
    {
        _transform.Translate(direction * (speed * Time.deltaTime));
        ClampWorldPosition();
    }

    private void TryShoot()
    {
        _remainingSecondsToCanShoot -= Time.deltaTime;

        if (_remainingSecondsToCanShoot > 0)
        {
            return;
        }

        if (_input.IsFireActionPressed())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        _remainingSecondsToCanShoot = _fireRateInSeconds;
        Instantiate(_projectilePrefab, _projectileSpawnPos.position, _projectileSpawnPos.rotation);
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