using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class wrog : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    public GameObject player;
    public int zdrowie = 50;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("spaceRockets_004");
    }

    void Update()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * speed;
        if (zdrowie <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
