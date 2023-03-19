using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Factory/Projectile", order = 0)]
public class ProjectileId : ScriptableObject
{
    [SerializeField] private string _value;
        
    public string Value => _value;
}