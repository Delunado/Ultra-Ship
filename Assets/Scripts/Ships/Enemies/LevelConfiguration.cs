using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelConfiguration", fileName = "LevelConfiguration")]
public class LevelConfiguration : ScriptableObject
{
    [SerializeField] private SpawnConfiguration[] _spawnConfigurations;
    
    public SpawnConfiguration[] SpawnConfigurations => _spawnConfigurations;
}