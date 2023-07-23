using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrogowieRespieni : MonoBehaviour
{
    public GameObject[] wrogowie;
    public List<GameObject> zrespieni;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(respienie());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator respienie()
    {
        yield return new WaitForSeconds(5);
        GameObject zrespiony = Instantiate(wrogowie[Random.Range(0, wrogowie.Length - 1)]);
        zrespieni.Add(zrespiony);
        zrespiony.transform.parent = parent.transform;
        zrespiony.transform.position = transform.position + new Vector3(Random.Range(20, 50), Random.Range(20, 50));
        StartCoroutine(respienie());
    }
}
