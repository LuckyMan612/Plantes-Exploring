using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wylaczAnimator : MonoBehaviour
{
    public bool czyWylaczyc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (czyWylaczyc)
        {
            GetComponent<Animator>().enabled = false;
            Debug.Log($"Wylaczono {GetComponent<Animator>()} {GetComponent<Animator>().enabled}");
        }
    }
}
