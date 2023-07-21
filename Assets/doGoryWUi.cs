using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class doGoryWUi : MonoBehaviour
{
    public int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, speed), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
