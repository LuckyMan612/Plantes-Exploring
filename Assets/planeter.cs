using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class planeter : MonoBehaviour
{
    public Sprite planetaTexture;
    public GameObject planeta;

    [Header("Liczby")]
    public float temperautura;
    public float cisnienie;
    public string woda;

    [Header("Opcje")]
    public GameObject temperaturaTxT;
    public GameObject wodaTxT;
    public GameObject cisnienieTxT;

    [Header("Sprawdzanie")]
    public bool _temperatura;
    public bool _cisnienie;
    public bool _woda;

    [Header("wylaczanie i wlaczanie")]
    public GameObject[] coWylaczyc;

    [Header("Dzwieki")]
    public AudioSource taskInProgress;
    public AudioSource taskComplete;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Nowa()
    {
        temperaturaTxT.transform.parent.gameObject.SetActive(true);
        wodaTxT.transform.parent.gameObject.SetActive(true);
        cisnienieTxT.transform.parent.gameObject.SetActive(true);

        planeta.GetComponent<SpriteRenderer>().sprite = planetaTexture;
        temperautura = Random.Range(50, 100);
        cisnienie = Random.Range(1200, 1600);
        foreach (GameObject item in coWylaczyc)
        {
            item.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        temperaturaTxT.GetComponent<TextMeshProUGUI>().text = temperautura.ToString() + "C";
        wodaTxT.GetComponent<TextMeshProUGUI>().text = woda.ToString() + "L";
        cisnienieTxT.GetComponent<TextMeshProUGUI>().text = cisnienie.ToString() + "hPa";
        if (!temperaturaTxT.transform.parent.gameObject.activeInHierarchy && !wodaTxT.transform.parent.gameObject.activeInHierarchy && !cisnienieTxT.transform.parent.gameObject.activeInHierarchy)
        {
            taskComplete.Play();
            foreach (GameObject item in coWylaczyc)
            {
                item.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
    public void PodwyzszTemperature()
    {
        temperautura += 10;
    }
    public void podnizszTemperature()
    {
        temperautura -= 10;
        if (temperautura <= 20)
        {
            _temperatura = true;
            temperaturaTxT.transform.parent.gameObject.SetActive(false);
            taskInProgress.Play();
        }
    }
    public void podwyzszWode()
    {
        woda = "unlimited";
        _woda = true;
        wodaTxT.transform.parent.gameObject.SetActive(false);
        taskInProgress.Play();
    }
    public void podnizszWode()
    {
        
    }
    public void podwyzszCisnienie()
    {
        cisnienie += 15;
    }
    public void podnizszCisnienie()
    {
        cisnienie -= 15;
        if (cisnienie <= 1005)
        {
            _cisnienie = true;
            cisnienieTxT.transform.parent.gameObject.SetActive(false);
            taskInProgress.Play();
        }
    }
}
