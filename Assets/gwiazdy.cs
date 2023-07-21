using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gwiazdy : MonoBehaviour
{
    public GameObject gwiazda;
    public int ileGwiazd;
    public GameObject parentGwiazd;
    public List<GameObject> gwiazdaList;

    [Header("Square")]
    public GameObject lewo;
    public GameObject prawo;
    public GameObject gora;
    public GameObject dol;
    public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = ileGwiazd; i != 0; i--)
        {
            ZrespGwiazde();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.isMoving)
        {
            foreach (GameObject item in gwiazdaList)
            {
                Destroy(item.gameObject);
                gwiazdaList.Remove(item);
                ZrespGwiazde();
            }
        }
        /*// ZBUGOWANY SYSTEM (JAK ZNAJDE CZAS TO NAPRAWIE)
        foreach (GameObject item in gwiazdaList)
        {
            if (item.transform.position.x < lewo.transform.position.x)
            {
                Destroy(item.gameObject);
                gwiazdaList.Remove(item);
                ZrespGwiazde();
            }
            if (item.transform.position.x > prawo.transform.position.x)
            {
                Destroy(item.gameObject);
                gwiazdaList.Remove(item);
                ZrespGwiazde();
            }
            if (item.transform.position.x > gora.transform.position.y)
            {
                Destroy(item.gameObject);
                gwiazdaList.Remove(item);
                ZrespGwiazde();
            }
            if (item.transform.position.x < dol.transform.position.y)
            {
                Destroy(item.gameObject);
                gwiazdaList.Remove(item);
                ZrespGwiazde();
            }
        }*/
        // ANULOWANO
        // Kiedy gracz sie rusza to niech sie zmienia
    }
    public void ZrespGwiazde()
    {
        GameObject taGwiazda = Instantiate(gwiazda);
        gwiazdaList.Add(taGwiazda);
        gwiazda.transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(Random.Range(-9, 14), Random.Range(-5, 3.5f));
        RandomowaSkala(taGwiazda, Random.Range(0.1f, 0.9f));
        taGwiazda.transform.SetParent(parentGwiazd.transform, true);

    }
    public void RandomowaSkala(GameObject objekt, float randomowa)
    {
        objekt.transform.localScale = new Vector2(randomowa, randomowa);
    }
}
