using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInstaller : MonoBehaviour
{
    private Ship _ship;

    [SerializeField] private bool useIA;
    [SerializeField] private bool checkLimitsFromPosition;

    private void Awake()
    {
        _ship = FindObjectOfType<Ship>();

        if (_ship != null)
        {
            _ship.Configure(GetInput(), GetCheckLimitsStrategy());
        }
        else
        {
            Debug.Log("SHIP IS NOT IN SCENE");
        }
    }

    private IInput GetInput()
    {
        if (useIA)
            return new IAInputAdapter(_ship);
        
        return new PCInputAdapter();
    }

    private ICheckLimits GetCheckLimitsStrategy()
    {
        if (checkLimitsFromPosition)
        {
            return new InitialPositionCheckLimits(_ship.transform, 7.0f);
        }
        
        return new ViewportCheckLimits(Camera.main, _ship.transform);
    }
}