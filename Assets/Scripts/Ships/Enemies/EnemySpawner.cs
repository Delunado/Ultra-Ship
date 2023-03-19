using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private LevelConfiguration _levelConfiguration;
    [SerializeField] private ShipConfiguration _shipConfiguration;

    private ShipFactory _shipFactory;

    private float _currentTime;
    private int _currentConfigurationIndex;

    private void Awake()
    {
        _shipFactory = new ShipFactory(Instantiate(_shipConfiguration));
    }

    private void Update()
    {
        if (_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length) return;

        _currentTime += Time.deltaTime;
        SpawnConfiguration currentConfiguration = _levelConfiguration.SpawnConfigurations[_currentConfigurationIndex];

        if (_currentTime < currentConfiguration.TimeToSpawn) return;

        SpawnEnemy(currentConfiguration);
        _currentConfigurationIndex++;
    }

    private void SpawnEnemy(SpawnConfiguration currentConfiguration)
    {
        for (int i = 0; i < currentConfiguration.ShipsToSpawnConfigurations.Length; i++)
        {
            ShipToSpawnConfiguration shipToSpawnConfiguration = currentConfiguration.ShipsToSpawnConfigurations[i];

            ShipMediator ship = _shipFactory.Create(shipToSpawnConfiguration.ShipId.Value,
                _spawnPoints[i % _spawnPoints.Length].position,
                _spawnPoints[i % _spawnPoints.Length].rotation);

            ship.Configure(new IAInputAdapter(ship), new InitialPositionCheckLimits(ship.transform, 20.0f),
                shipToSpawnConfiguration.Speed, shipToSpawnConfiguration.ProjectileId, shipToSpawnConfiguration.FireRate);
        }
    }
}