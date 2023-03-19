using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFactory
{
    private readonly ShipConfiguration _shipConfiguration;

    public ShipFactory(ShipConfiguration shipConfiguration)
    {
        _shipConfiguration = shipConfiguration;
    }
    
    public ShipMediator Create(string id, Vector2 position, Quaternion rotation)
    {
        ShipMediator ship = _shipConfiguration.GetShipById(id);
        
        return Object.Instantiate(ship, position, rotation);
    }
}
