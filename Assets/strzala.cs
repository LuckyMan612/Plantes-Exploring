using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class strzala : MonoBehaviour
{
    public float speed = 8.0f;
    private Rigidbody2D rb;
    public Vector3 wCoTrafi;
    public AudioClip[] ac;
    public GameObject dzwiekPb;
    public AudioClip dzwiekUmieraniaRobota;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<AudioSource>().clip = ac[Random.Range(0, ac.Length)];
        GetComponent<AudioSource>().Play();
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
        if (tag == "strzala")
        {
            if (collision.gameObject.CompareTag("wrog"))
            {
                Debug.Log("trafiono");
                collision.gameObject.GetComponent<wrog>().zdrowie -= 50;
                GameObject zrespiony = Instantiate(dzwiekPb);
                zrespiony.GetComponent<AudioSource>().clip = dzwiekUmieraniaRobota;
                zrespiony.GetComponent<AudioSource>().volume = 0.5f;
                zrespiony.GetComponent<AudioSource>().Play();
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "strzala")
        {
            if (collision.gameObject.CompareTag("wrog"))
            {
                Debug.Log("trafiono");
                collision.gameObject.GetComponent<wrog>().zdrowie -= 50;
                GameObject zrespiony = Instantiate(dzwiekPb);
                zrespiony.GetComponent<AudioSource>().clip = dzwiekUmieraniaRobota;
                zrespiony.GetComponent<AudioSource>().volume = 0.5f;
                zrespiony.GetComponent<AudioSource>().Play();
            }
        }
    }
}
