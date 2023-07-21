using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeter : MonoBehaviour
{
    public Sprite planetaTexture;
    public GameObject planeta;
    // Start is called before the first frame update
    void Start()
    {
        planeta.GetComponent<SpriteRenderer>().sprite = planetaTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
