using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInstaller : MonoBehaviour
{
    private Ship _ship;

    private void Awake()
    {
        _ship = FindObjectOfType<Ship>();

        if (_ship != null)
        {
            _ship.Configure(GetInput());
        }
        else
        {
            Debug.Log("SHIP IS NOT IN SCENE");
        }
    }

    private IInput GetInput()
    {
        return new PCInput();
    }
}