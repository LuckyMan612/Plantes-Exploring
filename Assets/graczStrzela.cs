using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graczStrzela : MonoBehaviour
{
    public bool czyMozeStrzelic = true;
    public GameObject strzalaPb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (czyMozeStrzelic && Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0;
            GameObject strzala = Instantiate(strzalaPb);
            strzala.transform.position = transform.position;
            strzala.GetComponent<strzala>().wCoTrafi = clickPosition;
            czyMozeStrzelic = false;
            Invoke("ustawNaTak", 0.5f);
        }
    }
    void ustawNaTak()
    {
        czyMozeStrzelic = true;
    }
}
