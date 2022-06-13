using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInstaller : MonoBehaviour
{
    private ShipMediator _shipMediator;

    [SerializeField] private bool useIA;
    [SerializeField] private bool checkLimitsFromPosition;

    private void Awake()
    {
        _shipMediator = FindObjectOfType<ShipMediator>();

        if (_shipMediator != null)
        {
            _shipMediator.Configure(GetInput(), GetCheckLimitsStrategy());
        }
        else
        {
            Debug.Log("SHIP IS NOT IN SCENE");
        }
    }

    private IInput GetInput()
    {
        if (useIA)
            return new IAInputAdapter(_shipMediator);
        
        return new PCInputAdapter();
    }

    private ICheckLimits GetCheckLimitsStrategy()
    {
        if (checkLimitsFromPosition)
        {
            return new InitialPositionCheckLimits(_shipMediator.transform, 7.0f);
        }
        
        return new ViewportCheckLimits(Camera.main, _shipMediator.transform);
    }
}