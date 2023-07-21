using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class gwiazda : MonoBehaviour
{
    public gwiazdy _gwiazdy;
    // Start is called before the first frame update
    void Start()
    {
        _gwiazdy = FindObjectOfType<gwiazdy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Opuszczono 2d");
        if (collision.gameObject.CompareTag("Respawn"))
        {
            _gwiazdy.ZrespGwiazde();
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Wejscie 2d");
        if (collision.gameObject.CompareTag("Respawn"))
        {
            _gwiazdy.ZrespGwiazde();
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Wejscie 3d");
        if (other.gameObject.CompareTag("Respawn"))
        {
            _gwiazdy.ZrespGwiazde();
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Wyjscie 3d");
        if (other.gameObject.CompareTag("Respawn"))
        {
            _gwiazdy.ZrespGwiazde();
            Destroy(other.gameObject);
        }
    }*/
}
