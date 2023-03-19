using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(fileName = "Ship Configuration", menuName = "Factory/Ship Configuration")]
public class ShipConfiguration : ScriptableObject
{
    [SerializeField] private ShipMediator[] _shipPrefabs;
    private Dictionary<string, ShipMediator> _idToShipPrefab;
    
    private void Awake()
    {
        _idToShipPrefab = new Dictionary<string, ShipMediator>();
        
        foreach (var ship in _shipPrefabs)
        {
            _idToShipPrefab.Add(ship.ID.Value, ship);
        }
    }
    
    public ShipMediator GetShipById(string id)
    {
        Assert.IsTrue(_idToShipPrefab.ContainsKey(id), $"Ship with id {id} not found");
        
        return _idToShipPrefab[id];
    }
}