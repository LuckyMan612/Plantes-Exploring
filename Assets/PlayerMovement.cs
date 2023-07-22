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
    public GameObject _isMoving;
    [Header("Strony")]
    public GameObject prawo;
    public GameObject lewo;
    public GameObject dol;
    public GameObject gora;
    [Header("temp")]
    bool czyJuzStartowal;
    public AudioSource fstart;
    public GameObject partiklesy;
    

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
        partikle();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, -90);
            WylaczWszystkieInne(prawo);
            if (!czyJuzStartowal)
            {
                firststart();
                czyJuzStartowal = true;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 90);
            WylaczWszystkieInne(lewo);
            if (!czyJuzStartowal)
            {
                firststart();
                czyJuzStartowal = true;
            }
        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            WylaczWszystkieInne(gora);
            if (!czyJuzStartowal)
            {
                firststart();
                czyJuzStartowal = true;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.up * -moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 180);
            WylaczWszystkieInne(dol);
            if (!czyJuzStartowal)
            {
                firststart();
                czyJuzStartowal = true;
            }
        }
    }
    void firststart()
    {
        fstart.Play();
        partiklesy.SetActive(true);
        partiklesy.GetComponentInChildren<ParticleSystem>().playOnAwake = false;
    }
    void WylaczWszystkieInne(GameObject ktory)
    {
        prawo.SetActive(false);
        lewo.SetActive(false);
        dol.SetActive(false);
        gora.SetActive(false);
        ktory.SetActive(true);
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
            pter.Nowa();
            
        }
    }

    void partikle()
    {
        if (isMoving) _isMoving.SetActive(true);
        else _isMoving.SetActive(false);
    }
}
