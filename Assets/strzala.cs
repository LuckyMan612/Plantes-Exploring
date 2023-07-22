using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class strzala : MonoBehaviour
{
    public float speed = 8.0f;
    private Rigidbody2D rb;
    public Vector3 wCoTrafi;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = (wCoTrafi - transform.position).normalized;
        rb.velocity = direction * speed;
    }
}
