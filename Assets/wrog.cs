    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wrog : MonoBehaviour
{
    public GameObject zielony;
    public GameObject czerwony;
    public bool _zielony;
    Vector3 pozycja;
    // Start is called before the first frame update
    void Start()
    {
        if (_zielony)
        {
            GameObject zrespiony = Instantiate(zielony);
            zrespiony.transform.position = transform.position;
            zrespiony.transform.localScale = transform.localScale;
            zrespiony.transform.rotation = transform.rotation;
            zrespiony.GetComponent<zdjecie>().target = this.gameObject.transform;
        }
        else
        {
            GameObject zrespiony = Instantiate(czerwony);
            zrespiony.transform.position = transform.position;
            zrespiony.transform.localScale = transform.localScale;
            zrespiony.transform.rotation = transform.rotation;
            zrespiony.GetComponent<zdjecie>().target = this.gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Kolizja z {collision.gameObject.tag}");
        if (collision.gameObject.CompareTag("wrog"))
        {
            //GetComponent<NavMeshAgent>().enabled = false;
        }
        pozycja = transform.position;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log($"Kolizja z {collision.gameObject.tag}");
        if (collision.gameObject.CompareTag("wrog"))
        {
            //GetComponent<NavMeshAgent>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log($"Kolizja z {collision.gameObject.tag}");
        if (collision.gameObject.CompareTag("wrog"))
        {
            //GetComponent<NavMeshAgent>().enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Kolizja z {collision.gameObject.tag}");
        if (collision.gameObject.CompareTag("wrog"))
        {
            //GetComponent<NavMeshAgent>().enabled = false;
        }
        pozycja = transform.position;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wrog"))
        {
            transform.position = pozycja;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wrog"))
        {
            transform.position = pozycja;
        }
    }

}
