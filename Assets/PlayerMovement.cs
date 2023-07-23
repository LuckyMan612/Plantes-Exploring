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
    public planety pty;
    [Header("ustawienie")]
    public bool _gora;
    public bool _prawo;
    public bool _lewo;
    public bool _dol;
    public bool klawiszE;
    // Start is called before the first frame update
    public void ustaw(string ktory)
    {
        switch (ktory)
        {
            case "gora":
                _gora = true;
                break;
            case "dol":
                _dol = true;
                break;
            case "prawo":
                _prawo = true;
                break;
            case "lewo":
                _lewo = true;
                break;
            case "e":
                klawiszE = true;
                break;
            default:
                break;
        }
    }
    public void wylacz(string ktory)
    {
        switch (ktory)
        {
            case "gora":
                _gora = false;
                break;
            case "dol":
                _dol = false;
                break;
            case "prawo":
                _prawo = false;
                break;
            case "lewo":
                _lewo = false;
                break;
            default:
                break;
        }
    }
    void sprawdzajIWykonuj()
    {
        if (_lewo) Lewo();
        else if (_prawo) Prawo();
        else if (_gora) Gora();
        else if (_dol) Dol();
    }


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
        sprawdzajIWykonuj();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Prawo();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Lewo();
        }

        else if (Input.GetKey(KeyCode.W))
        {
            Gora();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Dol();
        }
    }
    public void Prawo()
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
    public void Dol()
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
    public void Lewo()
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
    public void Gora()
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
        if (dotyka && Input.GetKey(KeyCode.E) || dotyka && klawiszE)
        {
            klawiszE = false;
            dotyka = false;
            pter.gameObject.SetActive(true);
            pter.planetaTexture = coDotyka.GetComponent<SpriteRenderer>().sprite;
            pty.planetyList.Remove(coDotyka);
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
