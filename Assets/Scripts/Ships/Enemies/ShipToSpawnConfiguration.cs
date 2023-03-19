using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ShipToSpawnConfiguration", fileName = "ShipToSpawnConfiguration")]
public class ShipToSpawnConfiguration : ScriptableObject
{
    [SerializeField] private ShipID _shipId;
    [SerializeField] private ProjectileId _projectileId;
    [SerializeField] private Vector2 _speed;
    [SerializeField] private float _fireRate;

    public ShipID ShipId => _shipId;
    public ProjectileId ProjectileId => _projectileId;
    public Vector2 Speed => _speed;
    public float FireRate => _fireRate;
}