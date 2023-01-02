using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(fileName = "Projectile Configuration", menuName = "Factory/Projectile Configuration")]
public class ProjectileConfiguration : ScriptableObject
{
    [SerializeField] private BaseProjectile[] _projectilePrefabs;
    private Dictionary<string, BaseProjectile> _idToProjectilePrefab;

    private void Awake()
    {
        _idToProjectilePrefab = new Dictionary<string, BaseProjectile>();
        foreach (var projectile in _projectilePrefabs)
        {
            _idToProjectilePrefab.Add(projectile.ID, projectile);
        }
    }
    
    public BaseProjectile GetProjectileById(string id)
    {
        Assert.IsTrue(_idToProjectilePrefab.ContainsKey(id), $"Projectile with id {id} not found");
        
        return _idToProjectilePrefab[id];
    }
}
