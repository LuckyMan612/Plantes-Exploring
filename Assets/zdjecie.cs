using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zdjecie : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + new Vector3(0.5f, 0, 0);
        transform.rotation = target.rotation;
        
    }
}
