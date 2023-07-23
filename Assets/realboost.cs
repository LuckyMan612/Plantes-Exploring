using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realboost : MonoBehaviour
{
    public hpIBoost hpiboost;
    public bool boosting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boost();
    }
    public void wlaczBoost()
    {
        boosting = true;
    }
    void boost()
    {
        if (hpiboost.boostEnabled && Input.GetKeyDown(hpiboost.boostKey) || hpiboost.boostEnabled && boosting)
        {
            boosting = false;
            hpiboost.boostEnabled = false;
            hpiboost.staraWartosc = hpiboost.GetComponent<PlayerMovement>().moveSpeed;
            hpiboost.GetComponent<PlayerMovement>().moveSpeed = hpiboost.speedOnBoost;
            StartCoroutine(booost());
        }
    }

    IEnumerator booost()
    {
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 4.5f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 4.0f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 3.5f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 3.0f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 2.5f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 2.0f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 1.5f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 1.0f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 0.5f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 0;

        hpiboost.GetComponent<PlayerMovement>().moveSpeed = hpiboost.staraWartosc;

        StartCoroutine(odPoczatku());

    }
    IEnumerator odPoczatku()
    {
        hpiboost.boostSlider.value = 0.5f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 1.0f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 1.5f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 2.0f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 2.5f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 3.0f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 3.5f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 4.0f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 4.5f;
        yield return new WaitForSeconds(0.5f);
        hpiboost.boostSlider.value = 5.0f;
        hpiboost.boostEnabled = true;
    }
}
