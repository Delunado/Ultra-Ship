using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private float _fireRateInSeconds;
    [SerializeField] private Projectile[] _projectilePrefabs;
    [SerializeField] private Transform _projectileSpawnPos;
    
    private IShip _ship;

    private string _activeProjectileID;
    private float lastTimeShooted;
    
    public void Configure(IShip ship)
    {
        _ship = ship;
    }

    public void TryShoot()
    {
        //Shoot if the last time shooted is more than the fire rate
        if (lastTimeShooted + _fireRateInSeconds < Time.time)
        {
            Shoot();
        }

        Shoot();
    }
    
    private void Shoot()
    {
        lastTimeShooted = Time.time;
        var projectile = _projectilePrefabs.First(projectile => projectile.ID.Equals(_activeProjectileID));
        Instantiate(projectile, _projectileSpawnPos.position, _projectileSpawnPos.rotation);
    }
}
