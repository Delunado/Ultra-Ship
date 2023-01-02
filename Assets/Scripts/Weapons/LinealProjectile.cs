using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LinealProjectile : BaseProjectile
{
    [SerializeField] private float _speed;

    protected override void DoStart()
    {
        rb.velocity = transform.up * _speed;
    }
    
    protected override void DoMove()
    {
        
    }

    protected override void DoDestroy()
    {
        
    }
}
