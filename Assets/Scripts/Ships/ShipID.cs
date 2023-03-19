using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Factory/Ship", order = 0)]
public class ShipID : ScriptableObject
{
    [SerializeField] private string _value;
        
    public string Value => _value;
}
