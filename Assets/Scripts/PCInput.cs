using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInput : IInput
{
    public Vector2 GetDirection()
    {
        float horDir = Input.GetAxis("Horizontal");
        float verDir = Input.GetAxis("Vertical");
        return new Vector2(horDir, verDir);
    }
}
