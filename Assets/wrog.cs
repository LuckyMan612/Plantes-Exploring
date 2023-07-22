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
    public bool isMoving;
    public bool czyMozeStrzelic = true;
    public GameObject strzalaPb;

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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wrog"))
        {
            if (czyMozeStrzelic)
            {
                GameObject strzala = Instantiate(strzalaPb);
                strzala.transform.position = transform.position;
                strzala.GetComponent<strzala>().wCoTrafi = player.transform.position;
                strzala.tag = "wGracza";
                czyMozeStrzelic = false;
                Invoke("cooldownStrzelania", 1);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wrog"))
        {
            if (czyMozeStrzelic)
            {
                GameObject strzala = Instantiate(strzalaPb);
                strzala.transform.position = transform.position;
                strzala.GetComponent<strzala>().wCoTrafi = player.transform.position;
                strzala.tag = "wGracza";
                czyMozeStrzelic = false;
                Invoke("cooldownStrzelania", 1);
            }
        }

    }
    void cooldownStrzelania()
    {
        czyMozeStrzelic = true;
    }
    

}
