using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apteczka : MonoBehaviour
{
    public GameObject apteczka;
    public GameObject dzwiekPb;
    public AudioClip dzwiekSlimu;
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
            if (collision.gameObject.GetComponent<hpIBoost>().hp != 500)
            {
                collision.gameObject.GetComponent<hpIBoost>().hp += 250;
                apteczka.gameObject.SetActive(false);
                Dzwiek();
                Invoke("odrodzenie", 5);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<hpIBoost>().hp != 500)
            {
                collision.gameObject.GetComponent<hpIBoost>().hp += 250;
                apteczka.gameObject.SetActive(false);
                Dzwiek();
                Invoke("odrodzenie", 5);
            }
        }
    }
    void odrodzenie()
    {
        apteczka.gameObject.SetActive(true);
    }
    void Dzwiek()
    {
        GameObject zrespiony = Instantiate(dzwiekPb);
        zrespiony.GetComponent<AudioSource>().clip = dzwiekSlimu;
        zrespiony.GetComponent<AudioSource>().volume = 0.7f;
        zrespiony.GetComponent<AudioSource>().Play();
    }
}
