using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApteczkaOdrodzenie : MonoBehaviour
{
    public GameObject apteczka;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void odrodz()
    {
        StartCoroutine(odrodzenie());
    }
    IEnumerator odrodzenie()
    {
        yield return new WaitForSecondsRealtime(30);
        apteczka.SetActive(true);
    }
}
