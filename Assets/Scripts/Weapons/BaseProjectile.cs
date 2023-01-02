using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseProjectile : MonoBehaviour
{
    [SerializeField] private ProjectileId _id;
    public string ID => _id.Value;

    protected Rigidbody2D rb;

    protected abstract void DoStart();
    protected abstract void DoMove();
    protected abstract void DoDestroy();

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyIn(3));

        DoStart();
    }

    private void FixedUpdate()
    {
        DoMove();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        DestroyProjectile();
    }

    private IEnumerator DestroyIn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        DoDestroy();
        Destroy(gameObject);
    }
}