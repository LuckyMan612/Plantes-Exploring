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

    [Header("Wyswietlacze")]
    public GameObject podTemperatura;
    public GameObject podCisnieniem;

    [Header("Listy")]
    public int[] temp;
    public int[] cisn;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Nowa()
    {
        temperaturaTxT.transform.parent.gameObject.SetActive(true);
        wodaTxT.transform.parent.gameObject.SetActive(true);
        cisnienieTxT.transform.parent.gameObject.SetActive(true);

        temperautura = temp[Random.Range(0, temp.Length)];
        cisnienie = cisn[Random.Range(0, cisn.Length)];
        woda = "100,146,312,462,354,175";

        planeta.GetComponent<SpriteRenderer>().sprite = planetaTexture;
        
        if (temperautura < 20) podTemperatura.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        if (cisnienie < 1005) podCisnieniem.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));

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
        sprawdzajTemperature();
    }
    public void podnizszTemperature()
    {
        temperautura -= 10;
        sprawdzajTemperature();
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
        cisnienie += 10;
        sprawdzajCisnienie();
    }
    public void podnizszCisnienie()
    {
        cisnienie -= 10;
        sprawdzajCisnienie();
    }
    private void sprawdzajCisnienie()
    {
        if (cisnienie == 1000)
        {
            _cisnienie = true;
            cisnienieTxT.transform.parent.gameObject.SetActive(false);
            taskInProgress.Play();
        }
    }
    private void sprawdzajTemperature()
    {
        if (temperautura == 20)
        {
            _temperatura = true;
            temperaturaTxT.transform.parent.gameObject.SetActive(false);
            taskInProgress.Play();
        }
    }
}
