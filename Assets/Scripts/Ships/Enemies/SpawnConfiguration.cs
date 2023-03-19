using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnConfiguration
{
    [SerializeField] private ShipToSpawnConfiguration[] _shipsToSpawnConfigurations;
    [SerializeField] private float _timeToSpawn;
    
    public ShipToSpawnConfiguration[] ShipsToSpawnConfigurations => _shipsToSpawnConfigurations;
    public float TimeToSpawn => _timeToSpawn;
}
