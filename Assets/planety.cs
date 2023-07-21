using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planety : MonoBehaviour
{
    public List<GameObject> planetyList;
    public GameObject[] _planety;
    public GameObject planetyParent;
    // Start is called before the first frame update
    void Start()
    {
        ZrespGwiazde();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    }
}
