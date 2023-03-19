using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory
{
    private readonly ProjectileConfiguration _projectileConfiguration;

    public ProjectileFactory(ProjectileConfiguration projectileConfiguration)
    {
        _projectileConfiguration = projectileConfiguration;
    }
    
    public BaseProjectile Create(string id, Vector2 position, Quaternion rotation)
    {
        BaseProjectile linealProjectilePrefab = _projectileConfiguration.GetProjectileById(id);
        
        BaseProjectile linealProjectile = Object.Instantiate(linealProjectilePrefab);
        
        linealProjectile.transform.position = position;
        linealProjectile.transform.rotation = rotation;
        return linealProjectile;
    }
}
