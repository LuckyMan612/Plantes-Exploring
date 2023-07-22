using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apteczka : MonoBehaviour
{
    public GameObject apteczka;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<hpIBoost>().hp = 200;
            apteczka.gameObject.SetActive(false);
            Invoke("odrodzenie", 5);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<hpIBoost>().hp = 200;
            apteczka.gameObject.SetActive(false);
            Invoke("odrodzenie", 5);
        }
    }
    void odrodzenie()
    {
        apteczka.gameObject.SetActive(true);
    }
}
