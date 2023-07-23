using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class planety : MonoBehaviour
{
    public List<GameObject> planetyList;
    public GameObject[] _planety;
    public GameObject planetyParent;
    public GameObject astronauta;
    public int speed = 30;
    public GameObject cospawnic;
    // Start is called before the first frame update
    void Start()
    {
        ZrespGwiazde();
    }

    // Update is called once per frame
    void Update()
    {
        Astronauta();
        //ManualLookAt2D();
        if (planetyList.Count == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    void Astronauta()
    {
        /*astronauta.transform.LookAt(planetyList[0].transform);
        astronauta.transform.rotation = Quaternion.Euler(astronauta.transform.rotation.x, 0, astronauta.transform.rotation.z);*/
        Vector2 direction = ((Vector2)_planety[0].transform.position - (Vector2)astronauta.transform.position).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var offset = 90f;
        astronauta.transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
    public void ZrespGwiazde()
    {
        foreach (GameObject go in _planety)
        {
            GameObject taPlaneta = Instantiate(go);
            planetyList.Add(taPlaneta);
            taPlaneta.transform.position = new Vector2(transform.position.x, transform.position.y) + new Vector2(Random.Range(-70, 70), Random.Range(-70, 70));
            taPlaneta.transform.SetParent(planetyParent.transform, true);
        }
        GameObject zespawnione = Instantiate(cospawnic);
        zespawnione.transform.position = new Vector2(70, 70);
        GameObject _zespawnione = Instantiate(cospawnic);
        _zespawnione.transform.position = new Vector2(-70, -70);
    }
    // Assign in inspector the gameobject you want to look at


// Rotation modifier makes a correction on the rotation axis and allows us to adjust the look

    // at from axis the one we want to be (just try it and you will understand what it means easily)

float rotationModifier = 90;


    // Call the function in fixedUpdate

    private void FixedUpdate()

    {

        ManualLookAt2D();

    }


    private void ManualLookAt2D()

    {

        // Calculate the difference between our gameObject and the desired target

        Vector3 vectorToTarget = planetyList[0].transform.position - astronauta.transform.position;

        // This functions serves as conversion from 3D space to 2D space

        // Forward makes the look at axis being the x axis

        // Returns the angle in radians whose Tan is y/x.

        // Return value is the angle between the x-axis and a 2D vector starting at zero and terminating at (x,y).

        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;


        // Sets the transform's current rotation to a new rotation that rotates “angle” degrees around

        // the - y-axis(Vector3.up), z-axis (Vector3.forward), x-axis (Vector.right)

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);


        // Smoothly rotates from our gameObject current rotation to the desired rotation to look

        // at the target

        astronauta.transform.rotation = Quaternion.Slerp(astronauta.transform.rotation, q, Time.deltaTime * speed);
        astronauta.transform.rotation = Quaternion.Euler(astronauta.transform.rotation.x, 0, astronauta.transform.rotation.z + 180);

    }
}
