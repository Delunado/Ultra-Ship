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
    
    public Projectile Create(string id, Vector2 position, Quaternion rotation)
    {
        Projectile projectilePrefab = _projectileConfiguration.GetProjectileById(id);
        
        Projectile projectile = Object.Instantiate(projectilePrefab);
        
        projectile.transform.position = position;
        projectile.transform.rotation = rotation;
        return projectile;
    }
}
