using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    Vector3 pozycja;
    public bool isMoving;

    private void Awake()
    {
        pozycja = transform.position;
    }
    void Start()
    {

    }


    void Update()
    {
        Movement();
        WykrywaniePredkosci();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, -90);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.up * -moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
    void WykrywaniePredkosci()
    {
        if (pozycja != transform.position) isMoving = true;
        else isMoving = false;
        pozycja = transform.position;
        
    }
}
