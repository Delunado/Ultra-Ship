using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInputAdapter : IInput
{
    public Vector2 GetDirection()
    {
        float horDir = Input.GetAxis("Horizontal");
        float verDir = Input.GetAxis("Vertical");
        return new Vector2(horDir, verDir);
    }

    public bool IsFireActionPressed()
    {
        return Input.GetButtonDown("Fire1");
    }
}
