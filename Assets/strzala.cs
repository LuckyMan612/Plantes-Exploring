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
        if (Vector3.Distance(transform.position, wCoTrafi) <= 0.1)
        {
            Debug.Log(Vector3.Distance(transform.position, wCoTrafi));
            Destroy(this.gameObject);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wrog"))
        {
            Debug.Log("trafiono");
            collision.gameObject.GetComponent<wrog>().zdrowie -= 50;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wrog"))
        {
            Debug.Log("trafiono");
            collision.gameObject.GetComponent<wrog>().zdrowie -= 50;
        }
    }
}
