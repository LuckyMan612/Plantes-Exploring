using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    Vector3 pozycja;
    public bool isMoving;
    public GameObject[] coUruchomicPrzyKolizjiZPlaneta;
    public bool dotyka;
    public GameObject coDotyka;
    public planeter pter;

    private void Awake()
    {
        pozycja = transform.position;
    }
    void Start()
    {

    }


    void Update()
    {
        Movement();
        WykrywaniePredkosci();
        wykrywanieWejsciaDoPlanety();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, -90);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.up * -moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
    void WykrywaniePredkosci()
    {
        if (pozycja != transform.position) isMoving = true;
        else isMoving = false;
        pozycja = transform.position;
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("planeta"))
        {
            Debug.Log("dotykanie planety collision");
            foreach (GameObject item in coUruchomicPrzyKolizjiZPlaneta)
            {
                item.SetActive(true);
            }
            dotyka = true;
            coDotyka = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("planeta"))
        {
            Debug.Log("wyjscie z dotykania planety collision");
            foreach (GameObject item in coUruchomicPrzyKolizjiZPlaneta)
            {
                item.SetActive(false);
            }
            dotyka = false;
            coDotyka = null;
        }
    }
    
    void wykrywanieWejsciaDoPlanety()
    {
        if (dotyka && Input.GetKey(KeyCode.E))
        {
            dotyka = false;
            pter.gameObject.SetActive(true);
            pter.planetaTexture = coDotyka.GetComponent<SpriteRenderer>().sprite;
            Destroy(coDotyka);
        }
    }
}
