using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class meteoryt : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("spaceRockets_004");

        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

}
