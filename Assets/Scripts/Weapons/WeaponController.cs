using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private float _fireRateInSeconds;
    [SerializeField] private ProjectileConfiguration _projectileConfiguration;
    [SerializeField] private ProjectileId _projectileId1;
    [SerializeField] private ProjectileId _projectileId2;
    [SerializeField] private Transform _projectileSpawnPos;

    private IShip _ship;
    private ProjectileFactory _projectileFactory;

    private ProjectileId _activeProjectileID;
    private float lastTimeShooted;

    public void Configure(IShip ship, ProjectileId projectileId, float fireRate)
    {
        _ship = ship;
        
        _fireRateInSeconds = fireRate;
        _activeProjectileID = projectileId;
        
        _projectileFactory = new ProjectileFactory(Instantiate(_projectileConfiguration));
    }

    public void TryShoot()
    {
        //Shoot if the last time shooted is more than the fire rate
        if (lastTimeShooted + _fireRateInSeconds < Time.time)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        lastTimeShooted = Time.time;
        
        BaseProjectile projectile = _projectileFactory.Create(_activeProjectileID.Value, _projectileSpawnPos.position,
            _projectileSpawnPos.rotation);
    }
}