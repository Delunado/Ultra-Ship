using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(fileName = "Projectile Configuration", menuName = "Factory/Projectile Configuration")]
public class ProjectileConfiguration : ScriptableObject
{
    [SerializeField] private Projectile[] _projectilePrefabs;
    private Dictionary<string, Projectile> _idToProjectilePrefab;

    private void Awake()
    {
        _idToProjectilePrefab = new Dictionary<string, Projectile>();
        foreach (var projectile in _projectilePrefabs)
        {
            _idToProjectilePrefab.Add(projectile.ID, projectile);
        }
    }
    
    public Projectile GetProjectileById(string id)
    {
        Assert.IsTrue(_idToProjectilePrefab.ContainsKey(id), $"Projectile with id {id} not found");
        
        return _idToProjectilePrefab[id];
    }
}
